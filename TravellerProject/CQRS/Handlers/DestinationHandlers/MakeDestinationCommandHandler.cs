using DataAccessLayer.Concrete;
using TravellerProject.CQRS.Command.DestinationCommands;

namespace TravellerProject.CQRS.Handlers.DestinationHandlers
{
    public class MakeDestinationCommandHandler
    {
        private readonly Context _context;

        public MakeDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(MakeDestinationCommand makeDestinationCommand)
        {
            _context.Destinations.Add(new EntityLayer.Concrete.Destination
            {
                City = makeDestinationCommand.City,
                Price = makeDestinationCommand.Price,
                Capacity = makeDestinationCommand.Capacity,
                Status = true,
                DayNight = makeDestinationCommand.DayNight,
            });
            _context.SaveChanges();

        }

    }
}
