
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models;

namespace RookiesFashion.APIService.Services
{
    public interface IProductService : IDisposable
    {
        Task<ServiceResponse> GetProducts();
        Task<ServiceResponse> GetProductById(int productId);
        Task<ServiceResponse> InsertProduct(Product product);
        Task<ServiceResponse> UpdateProduct(Product product);
        Task<ServiceResponse> DeleteProduct(int productId);
        bool IsExist(int productId, out Product product);
    }
}