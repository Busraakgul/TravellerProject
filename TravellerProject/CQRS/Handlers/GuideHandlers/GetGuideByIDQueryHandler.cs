using DataAccessLayer.Concrete;
using MediatR;
using NuGet.Protocol.Plugins;
using TravellerProject.CQRS.Query.GuideQueries;
using TravellerProject.CQRS.Results.GuideResults;

namespace TravellerProject.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIDQueryResult
            {
                GuideID = values.GuideID,
                Description = values.Description,
                Image = values.Image,
                Name = values.Name,
            };
        }
    }
}
