using RookiesFashion.APIService.Models;
using RookiesFashion.SharedRepo.Helpers;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.SharedRepo.DTO;

namespace RookiesFashion.APIService.Services.Interfaces;
public interface IRatingService
{
    Task<ServiceResponse> GetPagingRating(int productId, RatingBaseQueryCriteriaDto baseQueryCriteriaDto, CancellationToken cancellationToken);
    
    Task<ServiceResponse> InsertRating(Rating rating);
    bool IsExist(int ratingId, out Rating rating);
}