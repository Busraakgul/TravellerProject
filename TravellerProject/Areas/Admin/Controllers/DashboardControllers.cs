using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DashboardControllers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
