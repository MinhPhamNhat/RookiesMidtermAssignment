
using RookiesFashion.APIService.Models;
using RookiesFashion.SharedRepo.DTO;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.APIService.Services.Interfaces;
public interface IProductService
{
    Task<ServiceResponse> GetProducts();
    Task<ServiceResponse> GetProductById(int productId);
    Task<ServiceResponse> GetPagedProductFilter(ProductBaseQueryCriteriaDto baseQuery, CancellationToken cancellationToken);
    Task<ServiceResponse> GetProductWithPagingRating(int productId, RatingBaseQueryCriteriaDto baseQuery, CancellationToken cancellationToken);
    Task<ServiceResponse> InsertProduct(Product product);
    Task<ServiceResponse> UpdateProduct(Product product);
    Task<ServiceResponse> DeleteProduct(int productId);
    bool IsExist(int productId, out Product product);
}