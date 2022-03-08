using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RookiesFashion.APIService.Models
{
    [Table("Category")]
    public class Category : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
        public bool IsParent { get; set; }  = false;

        public int? ParentCategoryId { get; set; }
        public virtual Category? Parent { get; set; }

        public virtual IEnumerable<Category>? Children { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Product>? Products {get; set;}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Name))
            {
                yield return new ValidationResult("Category name cannot be null or empty", new[] { nameof(Name) });
            }
            if (string.IsNullOrEmpty(Description))
            {
                yield return new ValidationResult("Category description cannot be null or empty", new[] { nameof(Description) });
            }
            if (IsParent && ParentCategoryId != null || !IsParent && ParentCategoryId == null)
            {
                yield return new ValidationResult("Category must be a parent or must have parent Category", new[] { nameof(ParentCategoryId), nameof(IsParent) });
            }
        }
    }
}
