using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.SharedRepo.DTO;

public class BaseQueryCriteriaDto
{
    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 8;

}