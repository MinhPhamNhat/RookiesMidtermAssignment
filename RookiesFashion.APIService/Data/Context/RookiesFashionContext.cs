using Microsoft.EntityFrameworkCore;
using RookiesFashion.APIService.Models;
namespace RookiesFashion.APIService.Data.Context
{
    public class RookiesFashionContext : DbContext
    {
        public RookiesFashionContext(DbContextOptions<RookiesFashionContext> dbContextOptions) : base(dbContextOptions)
        {
            Console.WriteLine("Context Initiated");
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Product>().HasMany(p=>p.Colors).WithMany(c=>c.Products).LeftNavigation.ForeignKey.DeleteBehavior = DeleteBehavior.Restrict;
            // modelBuilder.Entity<Product>().HasMany(p=>p.Colors).WithMany(c=>c.Products).RightNavigation.ForeignKey.DeleteBehavior = DeleteBehavior.Restrict;
            modelBuilder.Seed();
            // modelBuilder.Entity<Image>()
            // .HasOne(i => i.Product)
            // .WithMany(p => p.Thumbnail)
            // .OnDelete(DeleteBehavior.ClientCascade);
            // modelBuilder.Entity<Product>()
            // .HasMany(p => p.Thumbnail)
            // .WithOne(i=>i.Product)
            // .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}