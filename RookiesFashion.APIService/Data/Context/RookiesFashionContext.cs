using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RookiesFashion.APIService.Models;
namespace RookiesFashion.APIService.Data.Context
{
    public class RookiesFashionContext : IdentityDbContext<User>
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
        public DbSet<UpdatedDate> UpdatedDates { get; set; }
               protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}