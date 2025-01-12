using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.ViewComponents.Default
{
    public class _Statistics: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.v1 = c.Destinations.Count();//Rota number
            ViewBag.v2 = c.Guides.Count();
            ViewBag.v3 = "2907";
            ViewBag.v4 = 30;
            return View();
        }
    }
}
