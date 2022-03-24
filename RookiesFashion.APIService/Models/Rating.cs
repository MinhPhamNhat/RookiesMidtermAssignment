using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
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
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product? Product { get; set; }
        [Required]
        public string? UserRating { get; set; }
    }
}