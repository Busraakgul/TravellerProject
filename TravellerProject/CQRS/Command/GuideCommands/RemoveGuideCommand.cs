using MediatR;

namespace TravellerProject.CQRS.Command.GuideCommands
{
    public class RemoveGuideCommand : IRequest
    {
        public RemoveGuideCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
