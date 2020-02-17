using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.DbContexts
{
    public class TenantContext : EFCoreStoreDbContext
    {
        public TenantContext(DbContextOptions options) : base(options)
        {
            //base.Database.Migrate();
            //var tenant1 = new TenantInfo(
            //    Guid.NewGuid().ToString(),
            //    "tenant1",
            //    "Tenant 1",
            //    "server=localhost;user=root;password=password;port=3306",
            //    null
            //);
            //base.Add(tenant1);
        }
    }
}
