using EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.DbContexts
{
    public class EFCoreContext : DbContext
    {
        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {
            //base.Database.EnsureCreated();
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
        }
    }
}
