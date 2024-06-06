using Microsoft.EntityFrameworkCore;
using RZDModel.Data.RZD;
using RZDModel.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Repository
{
    public class PlannedRouteRepository : Repository<PlannedRoute>
    {
        public PlannedRouteRepository(RZDContext context) : base(context)
        {
        }
    }
}
