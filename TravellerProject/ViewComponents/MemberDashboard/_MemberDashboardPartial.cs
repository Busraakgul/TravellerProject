using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.ViewComponents.MemberDashboard
{
    public class _MemberDashboardPartial: ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _MemberDashboardPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }


        //public IViewComponentResult Invoke()
        //{
        //    var destinations = _destinationService.TGetList();
        //    return View(destinations);
        //}
        public IViewComponentResult Invoke()
        {
            var topDestinations = _destinationService.TGetTop3DestinationsByReservation();
            return View(topDestinations);
        }

    }
}
