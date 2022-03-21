using RookiesFashion.SharedRepo.Constants;
namespace RookiesFashion.SharedRepo.DTO;

public class ProductBaseQueryCriteriaDto: BaseQueryCriteriaDto
{
    public string? Search { get; set; }
    public double? Rating { get; set; }
    public int? CategoryId { get; set; }
    public ProductSortConstants? SortOrder { get; set; } = ProductSortConstants.ALL;

}