using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rzd
{
    public class PlannedRoute
    {
        [Key]
        public required int id { get; set; }

        public required int DepartureStation_id { get; set; }

        public required int ArrivalStatin_id { get; set; }

        public required int Train_id { get; set; }

        public required int NumberOfSeats { get; set; }

        public required int NumberOfSeatsSold { get; set; }

        public required DateTime DepartureDate { get; set; }

        public required DateTime ArrivalDate { get; set; }

        public required IList<int> Tickets_id { get; set; }

        public required Decimal Price { get; set; }
    }
}