using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rzd
{
    public class User
    {
        [Key]
        public required int id { get; set; }

        public int? BankAccount_id { get; set; }

        public required string FullName { get; set; }

        public required string Role { get; set; }
    }
}