using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rzd
{
    public class Ticket
    {
        [Key]
        public required int id { get; set; }

        public required int User_id { get; set; }

        public required int PlannedRoute_id { get; set; }

        public required DateTime SoldDate { get; set; }

        public required string Price { get; set; }
    }
}