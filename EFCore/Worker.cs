using Finbuckle.MultiTenant;
using Infrastructure.DbContexts;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EFCore
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _services;

        public Worker(ILogger<Worker> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var scopeServices = _services.CreateScope().ServiceProvider;
                var store = scopeServices.GetRequiredService<IMultiTenantStore>();

                store.TryAddAsync(new TenantInfo(Guid.NewGuid().ToString(), "tenant1", "Tenant 1", "server=localhost;user=root;password=password;database=BloggingTenant1;port=3306", null)).Wait();
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(3000, stoppingToken);
            }
        }
    }
}
