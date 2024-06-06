using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RZDModel.Data.RZD
{
    [PrimaryKey(nameof(Id))]
    public class PlannedRoute
    {
        [Key]
        public int Id { get; set; }

        public DateTime departureDate { get; set; }

        public DateTime ArrivalDate { get; set; }

        [ForeignKey(nameof(Path_id))]
        public int Path_id { get; set; }

        [ForeignKey(nameof(Train_id))]
        public int Train_id { get; set; }
    }
}
