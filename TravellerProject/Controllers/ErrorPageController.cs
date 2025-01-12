using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code) //Page name
        {
            return View();
        }
    }
}
