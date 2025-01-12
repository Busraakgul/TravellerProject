using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService appUserService, IReservationService reservationService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _appUserService.TGetList();
            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            if (values != null)
            {
                _appUserService.TDelete(values);
            }
            else
            {
                // Kullanıcı bulunamazsa hata mesajı dönebilir.
                TempData["ErrorMessage"] = "User not found.";
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            return View(values);
        }


        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _appUserService.TGetByID(appUser.Id);
                if (existingUser != null)
                {
                    _appUserService.TUpdate(appUser);
                    TempData["SuccessMessage"] = "User updated successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "User not found.";
                    return RedirectToAction("Index");
                }
            }

            TempData["ErrorMessage"] = "Invalid data.";
            return View(appUser);
        }



        public IActionResult CommentUser(int id)
        {
            _appUserService.TGetList();
            return View();
        }

        [HttpPost]
        public IActionResult CommentUser(AppUser appUser)
        {
            _appUserService.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithReservationByAccepted(id);
            return View(values);
        }
    }
}
