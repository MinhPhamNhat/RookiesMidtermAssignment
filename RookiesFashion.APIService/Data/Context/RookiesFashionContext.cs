using Microsoft.EntityFrameworkCore;
using RookiesFashion.APIService.Models;
namespace RookiesFashion.APIService.Data.Context
{
    public class RookiesFashionContext : DbContext
    {
        public RookiesFashionContext(DbContextOptions<RookiesFashionContext> dbContextOptions) : base(dbContextOptions) {
            Console.WriteLine("Context Initiated");
         }

         public RookiesFashionContext(){}

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Rating> Ratings { get; set; }

<<<<<<< Updated upstream
        protected override async void OnModelCreating(ModelBuilder modelBuilder){
=======
        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
>>>>>>> Stashed changes
            modelBuilder.Seed();
        }
    }
}