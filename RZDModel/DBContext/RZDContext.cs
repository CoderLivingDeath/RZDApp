using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RZDModel.Data.Payment;
using RZDModel.Data.RZD;

namespace RZDModel.DBContext
{
    public class RZDContext : DbContext
    {
        public DbSet<Train> trains { get; set; }
        public DbSet<Data.RZD.Path> paths {  get; set; }
        public DbSet<PlannedRoute> routes { get; set; }
        public DbSet<Destination> destination {  get; set; }
        public DbSet<PaymentData> paymentDatas { get; set; }
        public RZDContext() : base()
        {
            
        }

        public RZDContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
