using Microsoft.EntityFrameworkCore;
using RZDModel.Interfaces.Repositories;
using RZDModel.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        private DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if(entity != null)
            {
                _dbSet.Remove(entity);
                _dbContext.SaveChanges();
            }
        }

        public T Read(int id)
        {
            var entity = _dbSet.Find(id);
            if( entity != null )
            {
                return entity;
            }
            throw new InvalidOperationException();
        }

        public IEnumerable<T> ReadAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
