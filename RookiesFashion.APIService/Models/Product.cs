
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.APIService.Models
{
    [Table("Product")]
    public class Product : IValidatableObject
    {
        public Product()
        {
            this.Colors = new HashSet<Color>();
            this.Sizes = new HashSet<Size>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual Category? Category { get; set; }
        public virtual List<Rating>? Ratings { get; set; }
        public double? AvgRating { get => (Ratings==null||Ratings.Count()<=0)?0:Math.Round(Ratings.Aggregate<Rating, double>(0, (x, y) => x + ((double)y.RatingVal / Ratings.Count())), 1); }
        public virtual IEnumerable<UpdatedDate>? UpdatedDates { get; set; }
        public virtual IEnumerable<Image>? Thumbnail { get; set; }
        public virtual IEnumerable<Color>? Colors { get; set; }
        public virtual IEnumerable<Size>? Sizes { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Name must not be null or empty", new[] { nameof(Name) });
            }
            if (Price <= 0)
            {
                yield return new ValidationResult("Price must not be null or be larger than 0", new[] { nameof(Price) });
            }
            if (CategoryId == null)
            {
                yield return new ValidationResult("Product category cannot be null", new[] { nameof(CategoryId) });
            }
            if (CategoryId == null)
            {
                yield return new ValidationResult("Category cannot be null", new[] { nameof(CategoryId) });
            }
        }
    }
}