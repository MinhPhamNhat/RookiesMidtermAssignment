using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RookiesFashion.APIService.Models;

namespace RookiesFashion.APIService.Models
{
    [Table("Rating")]
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }

        [Required]
        public int RatingVal { get; set; }

        [Required]
        public virtual Product RatedProduct { get; set; }
        [Required]
        public virtual User UserRating { get; set; }
    }
}