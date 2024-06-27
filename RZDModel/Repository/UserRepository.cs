﻿using Microsoft.EntityFrameworkCore;
using rzd;
using RZDModel.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(RZDDBContext context) : base(context)
        {
        }
    }
}
