using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRAPI.DAL;
using SignalRAPI.Hubs;

namespace SignalRAPI.Model
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
            await _hubContext.Clients.All.SendAsync("CallVisitorList",/*GetVisitorChartList()*/"aaaa");
        }

        //chart'a verileri basacek method
        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();//yeni bir liste oluşturuldu
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                //command.CommandText = "SELECT * FROM crosstab( " +" 'SELECT \"VisitDate\", \"City\", \"CityVisitCount\"FROM \"Visitors\" ORDER BY 1, 2') AS ct(VisitDate date,City1 int, City2 int,  City3 int, City4 int, City5 int);";
                command.CommandText = "Select * From crosstab ( 'Select VisitDate,City,CityVisitCount From Visitors Order By 1, 2') As ct(VisitDate date,City1 int, City2 int, City3 int, City4 int, City5 int);";

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
                            visitorChart.Counts.Add(reader.GetInt32(x));
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
