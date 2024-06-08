using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rzd
{
    public class UserCredentials
    {
        [Key]
        public required int id { get; set; }

        public required int User_id { get; set; }

        public required string Login { get; set; }

        public required string Password { get; set; }
    }
}