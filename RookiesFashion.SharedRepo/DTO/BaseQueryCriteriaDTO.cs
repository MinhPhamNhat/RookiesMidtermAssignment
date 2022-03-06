using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.SharedRepo.DTO;

public class BaseQueryCriteriaDTO
{
    public string? Search { get; set; }
    public double? Rating { get; set; }
    public int? CategoryId { get; set; }
    public SortConstants? SortOrder { get; set; } = SortConstants.ALL;
    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 2;

}