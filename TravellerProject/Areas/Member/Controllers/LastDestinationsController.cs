using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]//Bunu ekleyerek çalışması sağlanır cshtml'in
    public class LastDestinationsController : Controller
    {

        private readonly IDestinationService _destinationService;

        public LastDestinationsController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetLastFourDestinations();
            return View(values);
        }
    }
}
