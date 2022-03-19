using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.SharedRepo.DTO;

public class CategoryBaseQueryCriteriaDto: BaseQueryCriteriaDto
{
    public string? Search { get; set; }
    public bool? IsParent { get; set; }
    public CategorySortConstants? SortOrder { get; set; } = CategorySortConstants.ALL;
}