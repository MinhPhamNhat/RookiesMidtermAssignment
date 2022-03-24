using RookiesFashion.SharedRepo.Constants;
namespace RookiesFashion.SharedRepo.DTO;

public class RatingBaseQueryCriteriaDto: BaseQueryCriteriaDto
{
    public int? Rating { get; set; } = 1;

}