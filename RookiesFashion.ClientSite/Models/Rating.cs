using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RookiesFashion.ClientSite.Models;

namespace RookiesFashion.ClientSite.Models
{
    public class Rating
    {
        public int RatingId { get; set; }

        public int RatingVal { get; set; }

        public int RatingProductId { get; set; }
        public Product? Product { get; set; }

        public int RatingUserId { get; set; }
        public User? UserRating { get; set; }
    }
}