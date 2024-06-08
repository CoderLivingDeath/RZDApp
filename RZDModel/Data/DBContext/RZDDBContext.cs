using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace RZDModel.Data.DBContext
{
    public class RZDDBContext : DbContext
    {
        public RZDDBContext() : base()
        {

        }

        public RZDDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
