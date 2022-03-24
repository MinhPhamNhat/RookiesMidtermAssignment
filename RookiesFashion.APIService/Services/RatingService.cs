using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.APIService.Models;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.SharedRepo.DTO;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.APIService.Extension;

namespace RookiesFashion.APIService.Services
{
    public class RatingService : IRatingService
    {
        private readonly RookiesFashionContext _context;
        public RatingService(RookiesFashionContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> GetPagingRating(int productId, RatingBaseQueryCriteriaDto baseQueryCriteria, CancellationToken cancellationToken)
        {
            try
            {
                var ratings = _context.Ratings.Where(r => r.ProductId == productId && !r.Product.IsDeleted).Reverse().AsQueryable();
                ratings = FilterHelper.RatingFilter(ratings, baseQueryCriteria);
                var pagedRatings = await ratings.PaginateAsync(baseQueryCriteria, cancellationToken);

                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.SUCCESS,
                    Message = "Successfully Get Ratings",
                    Data = pagedRatings
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.ERROR,
                    Message = ex.Message,
                    RespException = ex
                };
            }
        }

        public async Task<ServiceResponse> InsertRating(Rating rating)
        {
            try
            {
                _context.Ratings.Add(rating);
                _context.SaveChanges();

                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.DATA_CREATED,
                    Message = "Rating Created",
                    Data = rating
                };

            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.ERROR,
                    Message = ex.Message,
                    RespException = ex.InnerException
                };
            }
        }

        public bool IsExist(int ratingId, out Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}