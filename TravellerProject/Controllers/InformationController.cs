using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.Controllers
{

    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
