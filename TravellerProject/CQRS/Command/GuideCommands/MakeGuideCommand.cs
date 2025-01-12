using MediatR;

namespace TravellerProject.CQRS.Command.GuideCommands
{
    public class MakeGuideCommand : IRequest
    {
        public int GuideID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? TwitterUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public bool Status { get; set; }
    }
}
