using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rzd
{
    public class Station
    {
        [Key]
        public required int id { get; set; }

        public required string Title { get; set; }
    }
}