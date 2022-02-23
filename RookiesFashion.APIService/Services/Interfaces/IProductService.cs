
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.APIService.Services.Interfaces;
public interface IProductService
{
    Task<ServiceResponse> GetProducts();
    Task<ServiceResponse> GetProductById(int productId);
    Task<ServiceResponse> InsertProduct(Product product);
    Task<ServiceResponse> UpdateProduct(Product product);
    Task<ServiceResponse> DeleteProduct(int productId);
    bool IsExist(int productId, out Product product);
}