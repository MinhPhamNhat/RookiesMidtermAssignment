
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.APIService.Models.DTO
{
    public class CategoryFormDTO : IValidatableObject
    {
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ParentCategoryId { get; set; }

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
        }
    }
}