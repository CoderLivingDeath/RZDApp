using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Data.Payment
{
    [PrimaryKey(nameof(Id))]
    public class PaymentData
    {
        [Key]
        public int Id { get; set; }
        public Guid guid { get; set; }
        public string? RecipientName { get; set; }
        public string? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? CorrespondentAccountNumber { get; set; }
        public string? BIC { get; set; }
        public string? INN { get; set; }
        public string? KPP { get; set; }
        public string? KBK { get; set; }
        public string? PaymentPurpose { get; set; }
        public string? Price { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
