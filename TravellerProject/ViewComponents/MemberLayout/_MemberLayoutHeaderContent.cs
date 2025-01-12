using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.ViewComponents.MemberLayout
{
    public class _MemberLayoutHeaderContent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
