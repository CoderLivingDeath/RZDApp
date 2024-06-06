using Microsoft.EntityFrameworkCore;
using RZDModel.Data.Payment;
using RZDModel.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Repository
{
    public class PaymentDataRepository : Repository<PaymentData>
    {
        public PaymentDataRepository(RZDContext context) : base(context)
        {
        }
    }
}
