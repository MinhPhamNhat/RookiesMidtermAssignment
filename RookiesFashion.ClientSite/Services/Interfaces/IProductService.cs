
using RookiesFashion.ClientSite.Models;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.ClientSite.Services.Interfaces;
public interface IProductService
{
    Task<ServiceResponse> GetProducts();
    Task<ServiceResponse> GetProductById(int productId);
    Task<ServiceResponse> InsertProduct(Dictionary<string, object> payload,List<IFormFile> files);
    Task<ServiceResponse> UpdateProduct(Product product);
    Task<ServiceResponse> DeleteProduct(int productId);
    bool IsExist(int productId, out Product product);
}