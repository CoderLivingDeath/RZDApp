using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using rzd;
using RZDModel.Data.DBContext;
using RZDModel.Interfaces.Repositories;
using RZDModel.Interfaces.Services;
using RZDModel.Repository;
using RZDModel.Services;
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
            services.AddControllersWithViews();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => options.LoginPath = "/Authorization/Login");
            services.AddAuthorization();

            services.AddDbContext<RZDDBContext>(option =>
            {
                option.UseSqlite(configuration.GetConnectionString(AppsettingsKeys.RZDConnection));
            });

            services.AddScoped<IRepository<BankAccount>, BankAccountRepository>();
            services.AddScoped<IRepository<PlannedRoute>, PlannedRouteRepository>();
            services.AddScoped<IRepository<Station>, StationRepository>();
            services.AddScoped<IRepository<Ticket>, TicketRepository>();
            services.AddScoped<IRepository<Train>, TrainRepository>();
            services.AddScoped<IRepository<UserCredentials>, UserCredentialsRepository>();
            services.AddScoped<IRepository<User>, UserRepository>();

            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IRouteService, RouteService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITrainService, TrainService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStationService, StationService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();

        }

        private static void AppConfigure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
