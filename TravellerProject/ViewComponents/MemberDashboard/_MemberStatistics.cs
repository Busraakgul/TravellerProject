using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
namespace TravellerProject.ViewComponents.MemberDashboard
{
    public class _MemberStatistics : ViewComponent
    {
        //public IViewComponentResult Invoke()
        //{
        //    return View();
        //}

        private readonly UserManager<AppUser> _userManager;
        private readonly ReservationManager _reservationManager;

        public _MemberStatistics(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _reservationManager = new ReservationManager(new EFReservationDal());
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            ViewBag.memberName = user.UserName + " " + user.Surname;
            ViewBag.memberPhone = user.PhoneNumber;
            ViewBag.memberMail = user.Email;

            if (user != null)
            {
                var allReservations = _reservationManager.TGetList().Where(x => x.AppUserId == user.Id);

                ViewBag.ActiveReservations = allReservations.Count(x => x.Status == "Approved");
                ViewBag.PastReservations = allReservations.Count(x => x.Status == "Past Reservation");
                ViewBag.ApprovalReservations = allReservations.Count(x => x.Status == "Waiting for Approval");
            }

            return View();
        }


    }
}



