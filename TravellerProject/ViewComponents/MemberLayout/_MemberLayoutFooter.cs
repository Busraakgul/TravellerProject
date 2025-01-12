using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.ViewComponents.MemberLayout
{
    public class _MemberLayoutFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
