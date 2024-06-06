using Microsoft.EntityFrameworkCore;
using RZDModel.Data.Payment;
using RZDModel.Data.RZD;
using RZDModel.DBContext;
using RZDModel.Interfaces.Repositories;
using RZDModel.Repository;
using RZDModel.Repository.Base;
using System.Data.Common;
using WebRZD.Infrastructure;

namespace WebRZD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ServiceConfigure(builder.Services, builder.Configuration);

            var app = builder.Build();

            AppConfigure(app);

            app.Run();
                
        }

        private static void ServiceConfigure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<RZDContext>(option =>
            {
                option.UseSqlite(configuration.GetConnectionString(AppsettingsKeys.RZDConnection));
            });

            AddRZDRepositories();
            AddPaymentRepositroyes();

            void AddRZDRepositories()
            {
                services.AddScoped<IRepository<Destination>,DestinationRepository>();
                services.AddScoped<IRepository<RZDModel.Data.RZD.Path>,PathRepository >();
                services.AddScoped<IRepository<PlannedRoute>, PlannedRouteRepository>();
                services.AddScoped<IRepository<Train>, TrainRepository>();
            }

            void AddPaymentRepositroyes()
            {
                services.AddScoped<IRepository<PaymentData>, PaymentDataRepository>();
            }
        }

        private static void AppConfigure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
