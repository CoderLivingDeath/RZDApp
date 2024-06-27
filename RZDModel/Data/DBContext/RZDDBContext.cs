using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using rzd;

namespace RZDModel.Data.DBContext
{
    public class RZDDBContext : DbContext
    {
        public DbSet<BankAccount> bankAccounts { get; set; }
        public DbSet<PlannedRoute> plannedRoutes { get; set; }
        public DbSet<Station> stations { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Train> trains { get; set; }
        public DbSet<User> users { get; set; } 
        public DbSet<UserCredentials> userCredentials { get; set; } 


        public RZDDBContext() : base()
        {

        }

        public RZDDBContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
