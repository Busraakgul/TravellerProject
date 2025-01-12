using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.ViewComponents.MemberDashboard
{
    public class _PlatformSetting : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
