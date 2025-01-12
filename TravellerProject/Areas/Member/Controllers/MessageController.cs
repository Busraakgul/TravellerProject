using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
