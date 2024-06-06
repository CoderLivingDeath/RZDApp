using Microsoft.EntityFrameworkCore;
using RZDModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Repository.Base
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected DbContext _dbContext { get; set; }

        protected Repository(DbContext context)
        {
            _dbContext = context;
        }

        public abstract T Create(T entity);

        public abstract void Delete(int id);

        public abstract T Read(int id);

        public abstract IEnumerable<T> ReadAll();

        public abstract void Update(T entity);
    }
}
