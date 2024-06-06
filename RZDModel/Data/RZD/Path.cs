using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Data.RZD
{
    [PrimaryKey(nameof(Id))]
    public class Path
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(FromDestination_id))]
        public string FromDestination_id { get; set; }

        [ForeignKey(nameof(ToDestination_id))]
        public string ToDestination_id { get; private set; }
    }
}
