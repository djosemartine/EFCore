using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.EntityFrameworkCore;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
    public class BlogContext : MultiTenantDbContext
    {
        public BlogContext(TenantInfo tenantInfo) : base(tenantInfo)
        {
        }

        public BlogContext(TenantInfo tenantInfo, DbContextOptions options) : base(tenantInfo, options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>()
                .HasIndex(a => a.Email)
                .IsUnique();
            modelBuilder.Entity<Author>().IsMultiTenant();
            modelBuilder.Entity<Post>().IsMultiTenant();
            modelBuilder.Entity<Blog>().IsMultiTenant();
        }
    }
}
