namespace WebRZD.Models.RoutsModel
{
    public class RouteForm
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
        public bool IsAllSold { get; set; }
    }
}
