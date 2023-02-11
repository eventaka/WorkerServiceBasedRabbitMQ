using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ServiceBasedRabbit.Infrastructure.MessageBroker;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WorkerServiceBasedRabbitMQ.Infrastructure.DbContexts;

namespace WorkerServiceBasedRabbitMQ
{
    public class Worker : BackgroundService
    {

        private readonly ILogger<Worker> _logger;
        private readonly RabbitMQSubscriber _rabbitMQSubscriber;
        private readonly IServiceProvider _serviceProvider;


        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _rabbitMQSubscriber = new RabbitMQSubscriber();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var list = _rabbitMQSubscriber.Subscribe();

                // Save to DB
                using var scope = _serviceProvider.CreateScope();
                var services = scope.ServiceProvider;
                var appDbContext = services.GetService<AppDbContext>();
                if (list != null && list.Count() > 0)
                {
                    foreach (var item in list)
                    {
                        await appDbContext.User.AddAsync(item);
                    }
                    await appDbContext.SaveChangesAsync();
                }
            }
        }
    }
}
