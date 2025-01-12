using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic: ViewComponent
    {
        Context c =new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Destinations.Count(); //Number of tour
            ViewBag.v2 = c.Users.Count();  //Number of guests
            return View();
           
        }
    }
}
