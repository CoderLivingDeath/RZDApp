using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rzd
{
    public class User
    {
        [Key]
        public required int id { get; set; }

        [Key]
        public required int BankAccount_id { get; set; }

        public required string FullName { get; set; }
    }
}