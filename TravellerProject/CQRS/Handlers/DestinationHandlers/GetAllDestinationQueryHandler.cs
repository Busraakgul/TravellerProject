
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using TravellerProject.CQRS.Query.DestinationQueries;
using TravellerProject.CQRS.Results.DestinationResults;

namespace TravellerProject.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                id = x.DestinationID,
                capacity = x.Capacity,
                city = x.City,
                daynight = x.DayNight,
                price =x.Price
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
