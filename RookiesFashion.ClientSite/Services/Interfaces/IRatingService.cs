using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.ClientSite.Services.Interfaces;

public interface IRatingService
{
    Task<ServiceResponse> GetPagingRatings(RatingFormVM ratingForm);
    Task<ServiceResponse> InsertRating(RatingFormVM ratingForm);
}
