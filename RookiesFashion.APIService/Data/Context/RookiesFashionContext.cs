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
        // public double GetAverageRating(List<Rating> Ratings) => (Ratings == null || Ratings.Count() <= 0) ? 0 : Math.Round(Ratings.Aggregate<Rating, double>(0, (x, y) => x + ((double)y.RatingVal / Ratings.Count())), 1);
        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            // modelBuilder.HasDbFunction(typeof(RookiesFashionContext).GetMethod(nameof(GetAverageRating), new[] { typeof(List<Rating>)}))
            // .HasName("GetAverageRating");
        }
    }
}