using System.ComponentModel.DataAnnotations;

namespace RookiesFashion.ClientSite.Models;


public class Category: IValidatableObject
{
    public int CategoryId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }
    public bool IsParent { get; set; } = false;

    public int? ParentCategoryId { get; set; }
    public Category? Parent { get; set; }

    public IEnumerable<Category>? Children { get; set; }

    public IEnumerable<Product>? Products { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        throw new NotImplementedException();
    }
}