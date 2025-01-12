using DataAccessLayer.Concrete;
using MediatR;
using TravellerProject.CQRS.Command.GuideCommands;

namespace TravellerProject.CQRS.Handlers.GuideHandlers
{
    public class RemoveGuideCommandHandler : IRequestHandler<RemoveGuideCommand>
    {
        private readonly Context _context;
        public RemoveGuideCommandHandler(Context context)
        {
            _context = context;
        }
        public async Task Handle(RemoveGuideCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.Id);

            _context.Guides.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
