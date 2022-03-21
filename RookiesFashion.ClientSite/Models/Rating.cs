using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.Models
{
    public class Rating
    {
        public int RatingId { get; set; }

        public int RatingVal { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int RatingProductId { get; set; }
        public Product? Product { get; set; }
        public string? UserRating { get; set; }
    }
}