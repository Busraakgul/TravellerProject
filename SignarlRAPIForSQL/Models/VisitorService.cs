using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRAPIForSQL.DAL;
using SignalRAPIForSQL.Hubs;

namespace SignalRAPIForSQL.Models
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(Context context, IHubContext<VisitorHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();//Queryable bellek yönetiminde daha performanslıdır
        }

        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveVisitorList", GetVisitorChartList());
        }

        //chart'a verileri basacek method
        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();//yeni bir liste oluşturuldu
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                //command.CommandText = "Select * From crosstab ( 'Select VisitDate,City,CityVisitCount From Visitors Order By 1, 2') As ct(VisitDate date,City1 int, City2 int, City3 int, City4 int, City5 int);";
                //command.CommandText = "select Dates, [1],[2],[3],[4],[5],[6],[7] from (select[City], CityVisitCount, Cast([VisitDate] as Date) as Dates from Visitors) as VisitTable Pivot (sum(CityVisitCount) FOR City in ([1],[2],[3],[4],[5],[6),[7]) as PivotTable order by Dates asc";
                command.CommandText = @" SELECT Dates, 
                                        [1] AS City1,[2] AS City2,[3] AS City3,[4] AS City4,[5] AS City5,[6] AS City6,[7] AS City7 FROM 
                                        (SELECT City,CityVisitCount, CAST(VisitDate AS DATE) AS Dates FROM Visitors) AS VisitTable PIVOT 
                                        (SUM(CityVisitCount) FOR City IN ([1],[2],[3],[4],[5],[6],[7])) AS PivotTable ORDER BY Dates ASC";

                command.CommandType = System.Data.CommandType.Text;//query türünde
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart visitorChart = new VisitorChart();
                        visitorChart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 7).ToList().ForEach(x =>  //her şehir için tüm tarihleri ve sayısal değerleri ana listeye eklendi
                        {
                            visitorChart.Counts.Add(!reader.IsDBNull(x) ? reader.GetInt32(x) : 0);
                            //visitorChart.Counts.Add(reader.GetInt32(x));
                        });
                        visitorCharts.Add(visitorChart);
                    }
                }
                _context.Database.CloseConnection();
                return visitorCharts;
            }
        }
    }
}
