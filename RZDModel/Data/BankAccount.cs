using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rzd
{
    public class BankAccount
    {
        [Key]
        public required int id { get; set; }

        public required int User_id { get; set; }

        public required string CardNumber {  get; set; }
    }
}