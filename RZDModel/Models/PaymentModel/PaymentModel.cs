using RZDModel.Data.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Models.PaymentModel
{
    
    /// <summary>
    /// Эмитация платежной системы 
    /// </summary>
    public class PaymentModel
    {
        public bool AcceptPayment(PaymentData data)
        {
            return IsValid(data);
        }

        public bool IsValid(PaymentData data)
        {
            return data.guid != Guid.Empty &&
                   !string.IsNullOrEmpty(data.RecipientName) &&
                   !string.IsNullOrEmpty(data.AccountNumber) &&
                   !string.IsNullOrEmpty(data.BankName) &&
                   !string.IsNullOrEmpty(data.CorrespondentAccountNumber) &&
                   !string.IsNullOrEmpty(data.BIC) &&
                   !string.IsNullOrEmpty(data.INN) &&
                   !string.IsNullOrEmpty(data.KPP) &&
                   !string.IsNullOrEmpty(data.KBK) &&
                   !string.IsNullOrEmpty(data.PaymentPurpose) &&
                   !string.IsNullOrEmpty(data.Price) &&
                   data.PaymentDate != default;
        }
    }
}
