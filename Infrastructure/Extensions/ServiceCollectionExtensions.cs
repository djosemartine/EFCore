using Finbuckle.MultiTenant;
using Infrastructure.DbContexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TenantContext>(options =>
                {
                    options.UseMySql(configuration.GetConnectionString("TenantInfoDatabase"),
                        m => m.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().FullName));
                });
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddMultiTenant()
                .WithEFCoreStore<TenantContext>()
                .WithStaticStrategy("tenant1");
            return services;
        }
    }
}
