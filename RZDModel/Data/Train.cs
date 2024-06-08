using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rzd
{
    public class Train
    {
        [Key]
        public required int id { get; set; }

        public required int Capacity { get; set; }
    }
}