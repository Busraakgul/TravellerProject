using DataAccessLayer.Concrete;
using TravellerProject.CQRS.Command.DestinationCommands;

namespace TravellerProject.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand updateDestinationCommand)
        {
            var values = _context.Destinations.Find(updateDestinationCommand.DestinationID);
            values.City = updateDestinationCommand.City;
            values.DayNight = updateDestinationCommand.DayNight;
            values.Price = updateDestinationCommand.Price;  
            _context.SaveChanges();

        }
    }
}
