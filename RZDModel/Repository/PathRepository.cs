using Microsoft.EntityFrameworkCore;
using RZDModel.DBContext;
using RZDModel.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Repository
{
    public class PathRepository : Repository<Data.RZD.Path>
    {
        public PathRepository(RZDContext context) : base(context)
        {
        }
    }
}
