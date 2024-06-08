using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZDModel.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        void Create(T entity);
        T Read(int id);
        IEnumerable<T> ReadAll();
        void Update(T entity);
        void Delete(int id);
    }
}
