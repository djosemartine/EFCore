using EFCore.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace EFCore
{
    public static class Program
    {
        private static readonly string EnvironmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", false, true);
                    config.AddJsonFile($"appsettings.{EnvironmentName}.json", true, true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;
                    services.AddDbContext<EFCoreContext>(options =>
                    {
                        options.UseMySql(configuration.GetConnectionString("BloggingDatabase"));
                    });
                    services.AddHostedService<Worker>();
                });
    }
}
