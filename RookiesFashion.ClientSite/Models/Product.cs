using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.Models
{
    public class Product : IValidatableObject
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        // public virtual Category? Category { get; set; }
        // public virtual IEnumerable<UpdatedDate>? UpdatedDates { get; set; }
        // public virtual IEnumerable<Image>? Thumbnail { get; set; }
        // public virtual IEnumerable<Color>? Colors { get; set; }
        // public virtual IEnumerable<Size>? Sizes { get; set; }

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
            if (CategoryId == null){
                yield return new ValidationResult("Category cannot be null", new []{nameof(CategoryId)});
            }
        }
    }
}