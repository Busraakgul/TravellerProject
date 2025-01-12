using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.ViewComponents.AdminDashboard
{
    public class _DashboardBanner :ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
