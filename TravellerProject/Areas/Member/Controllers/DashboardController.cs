//using BusinessLayer.Abstract;
//using BusinessLayer.Concrete;
//using DataAccessLayer.EntityFramework;
//using EntityLayer.Concrete;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace TravellerProject.Areas.Member.Controllers
//{
//    [Area("Member")]
//    [Route("Member/[controller]/[action]")]//Bunu ekleyerek çalışması sağlanır cshtml'in

//    public class DashboardController : Controller
//    {
//        private readonly UserManager<AppUser> _userManager;

//        public DashboardController(UserManager<AppUser> userManager)
//        {
//            _userManager = userManager;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var values = await _userManager.FindByNameAsync(User.Identity.Name);
//            ViewBag.userName = values.Name + " " + values.Surname;
//            ViewBag.userImage = values.ImageUrl;
//            return View();
//        }

//        public async Task<IActionResult> MemberDashboard()
//        {
//            return View();
//        }

//    }
//}



using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravellerProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationService _destinationService;

        public DashboardController(UserManager<AppUser> userManager, IDestinationService destinationService)
        {
            _userManager = userManager;
            _destinationService = destinationService; // Inject DestinationService
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = values.Name + " " + values.Surname;
            ViewBag.userImage = values.ImageUrl;
            return View();
        }

        public async Task<IActionResult> MemberDashboard()
        {
            // Fetch destinations using the service
            List<Destination> destinations = _destinationService.TGetList(); // You can use TGetList() or another method

            // Pass the destinations to the view
            return View(destinations); // Ensure the view expects List<Destination>
        }
    }
}

