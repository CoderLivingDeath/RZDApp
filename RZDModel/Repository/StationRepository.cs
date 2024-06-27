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
    public class StationRepository : Repository<Station>
    {
        public StationRepository(RZDDBContext context) : base(context)
        {
        }
    }
}
