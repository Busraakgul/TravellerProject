using DataAccessLayer.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;
using TravellerProject.CQRS.Command.GuideCommands;

namespace TravellerProject.CQRS.Handlers.GuideHandlers
{
    public class MakeGuideCommandHandler : IRequestHandler<MakeGuideCommand>
    {
        private readonly Context _context;

        public MakeGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(MakeGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new EntityLayer.Concrete.Guide
            {
                Description = request.Description,
                Name = request.Name,
                Status = request.Status,
                Image = request.Image,

            });
            await _context.SaveChangesAsync();
            //return Unit.Value;
        }

    }
}
