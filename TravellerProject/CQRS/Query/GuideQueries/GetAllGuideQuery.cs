using MediatR;
using TravellerProject.CQRS.Results.GuideResults;

namespace TravellerProject.CQRS.Query.GuideQueries
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>> 
    {

    }
}
