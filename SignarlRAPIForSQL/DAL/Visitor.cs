namespace SignalRAPIForSQL.DAL

{
    public enum ECity
    {
        London = 1,
        Paris = 2,
        Berlin = 3,
        Sdyney = 4,
        Dubai = 5,
        Porto = 6,
        Barcelona = 7
    }
    public class Visitor
    {
        public int VisitorID { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
