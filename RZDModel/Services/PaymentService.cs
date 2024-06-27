using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RZDModel.Interfaces.Services;

namespace RZDModel.Services
{
    public class PaymentService : IPaymentService
    {
        public PaymentService() { }

        // Эмитация оплаты
        public bool PayByCard(string cardNumber, decimal price)
        {
            if (cardNumber.Length == 16)
            {
                bool isDigits = true;
                foreach (char c in cardNumber)
                {
                    isDigits = char.IsDigit(c) && isDigits;
                }

                return isDigits && price > 0;
            }

            return false;
        }
    }
}
