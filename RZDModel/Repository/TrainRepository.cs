using RZDModel.Repository.Base;
using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.Data.Sqlite;
using RZDModel.DBContext;
using RZDModel.Data.RZD;
using Microsoft.EntityFrameworkCore;
namespace RZDModel.Repository
{
    public class TrainRepository : Repository<Train>
    {
        public TrainRepository(RZDContext context) : base(context) { }
    }
}
