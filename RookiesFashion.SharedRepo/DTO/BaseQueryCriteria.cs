using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.SharedRepo.DTO;

public class BaseQueryCriteria
{
    public string? Search { get; set; }

    public SortConstants Sorter { get; set; }

    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 10;

}