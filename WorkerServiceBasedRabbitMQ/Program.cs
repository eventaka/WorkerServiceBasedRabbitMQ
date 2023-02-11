using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkerServiceBasedRabbitMQ.Core.Interfaces;
using WorkerServiceBasedRabbitMQ.Infrastructure.DbContexts;
using WorkerServiceBasedRabbitMQ.Infrastructure.Repositories;

namespace WorkerServiceBasedRabbitMQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                   
                    var con = hostContext.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
                    services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(con, ef => ef.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
                    
                    services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

                    services.AddScoped<ICreateUserRepository>(provider => provider.GetService<CreateUserRepository>());

                });
    }
}
