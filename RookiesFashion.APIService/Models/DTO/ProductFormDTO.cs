
using System.ComponentModel.DataAnnotations;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.SharedRepo.Helpers;
using RookiesFashion.APIService.Services;
using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.APIService.Models.DTO;
public class ProductFormDTO : IValidatableObject
{
    public int? ProductId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public double? Price { get; set; }
    [Required]
    public int? CategoryId { get; set; }

    [Required]
    public List<int>? ColorIds { get; set; }

    [Required]
    public List<int>? SizeIds { get; set; }
    [Required]
    public List<IFormFile>? Files { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Price <= 0)
        {
            yield return new ValidationResult("Price must not be null or be larger than 0", new[] { nameof(Price) });
        }
        if (Files?.Count() <= 0 && Files.Count() >= 3)
        {
            yield return new ValidationResult("Files must larger than 0 and less than 3", new[] { nameof(Files) });
        }
        else
        {
            if (!Files.All(f => f.ContentType.Contains("image")))
            {
                yield return new ValidationResult("Not all file is image", new[] { nameof(Files) });
            }
        }
    }
}