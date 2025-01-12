using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRAPI.DAL;
using SignalRAPI.Model;

namespace SignalRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _visitorService;

        public VisitorController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]
        public IActionResult MakeVisitor()
        {
            Random random = new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x =>
            {
                foreach (ECity eCity in Enum.GetValues(typeof(ECity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = eCity,
                        CityVisitCount = random.Next(100, 2000),
                        //VisitDate = DateTime.Now.AddDays(x)
                        VisitDate = DateTime.UtcNow.AddDays(x) // UTC olarak ayarlanıyor

                    };
                    _visitorService.SaveVisitor(newVisitor).Wait();
                    System.Threading.Thread.Sleep(1000);//her işlem bir defa döner
                }
            });
            return Ok("Visitors added successfully.");
        }
    }

}
