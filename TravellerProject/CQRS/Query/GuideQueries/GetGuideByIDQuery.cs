using MediatR;
using TravellerProject.CQRS.Results.GuideResults;

namespace TravellerProject.CQRS.Query.GuideQueries
{
    public class GetGuideByIDQuery : IRequest<GetGuideByIDQueryResult>
    {
        public GetGuideByIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
