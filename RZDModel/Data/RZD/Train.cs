using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Data.RZD
{
    [PrimaryKey(nameof(Id))]
    public class Train
    {
        [Key]
        public int Id { get; set; }

        public string Model { get; set; }
    }
}
