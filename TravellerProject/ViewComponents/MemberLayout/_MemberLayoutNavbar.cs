using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EntityLayer.Concrete;  
using System.Threading.Tasks;

namespace TravellerProject.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _MemberLayoutNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user != null)
            {
                ViewBag.memberName = $"{user.UserName} {user.Surname}";
                ViewBag.memberImage = user.ImageUrl ?? "/member/theme-assets/images/portrait/small/avatar-s-19.png";
            }
            else
            {
                ViewBag.memberName = "Guest";
                ViewBag.memberImage = "/member/theme-assets/images/portrait/small/avatar-s-19.png";
            }

            return View();
        }
    }
}
