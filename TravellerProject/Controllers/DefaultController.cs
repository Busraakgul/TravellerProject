using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.Controllers
{

    //[Area("Admin")]
    //[Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
