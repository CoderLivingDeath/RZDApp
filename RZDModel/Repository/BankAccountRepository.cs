using Microsoft.EntityFrameworkCore;
using rzd;
using RZDModel.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Repository
{

    public class BankAccountRepository : Repository<BankAccount>
    {
        public BankAccountRepository(RZDDBContext context) : base(context)
        {
        }
    }
}
