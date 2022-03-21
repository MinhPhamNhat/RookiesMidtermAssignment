using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.ViewModels
{
    public class RatingVM
    {
        public int RatingId { get; set; }

        public int RatingVal { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int RatingProductId { get; set; }
        public ProductVM? Product { get; set; }
        public string? UserRating { get; set; }

    }
}