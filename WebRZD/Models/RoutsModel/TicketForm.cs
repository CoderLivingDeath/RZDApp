namespace WebRZD.Models.RoutsModel
{
    public class TicketForm
    {
        public int RouteId { get; set; }
        public int TicketId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
    }
}
