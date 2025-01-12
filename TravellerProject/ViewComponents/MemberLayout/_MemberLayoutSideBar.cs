using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.ViewComponents.MemberLayout
{
    public class _MemberLayoutSideBar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
