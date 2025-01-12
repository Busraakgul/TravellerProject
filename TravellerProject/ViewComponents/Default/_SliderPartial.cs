using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.ViewComponents.Default
{
    public class _SliderPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
