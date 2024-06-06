using RZDModel.Data.Payment;
using RZDModel.Interfaces.Services;
using RZDModel.Models.PaymentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentModel _paymentModel;

        public PaymentService(PaymentModel paymentModel)
        {
            _paymentModel = paymentModel;
        }

        public bool Pay(PaymentData data)
        {
            if(IsValid(data))
            {
                return _paymentModel.AcceptPayment(data);
            }
            return false;
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
