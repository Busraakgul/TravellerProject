using DataAccessLayer.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;
using TravellerProject.CQRS.Command.GuideCommands;

namespace TravellerProject.CQRS.Handlers.GuideHandlers
{
    public class UpdateGuideCommandHandler : IRequestHandler<UpdateGuideCommand>
    {
        private readonly Context _context;
        public UpdateGuideCommandHandler(Context context)
        {
            _context = context;
        }
        public async Task Handle(UpdateGuideCommand request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.GuideID);

            values.Name = request.Name;
            values.Image = request.Image;
            values.Description = request.Description;
            await _context.SaveChangesAsync();

            //return Unit.Value;
        }
    }
}
