namespace TravellerProject.CQRS.Command.DestinationCommands
{
    public class MakeDestinationCommand
    {
        public string? City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
        public bool? Status { get; set; }
    }
}
