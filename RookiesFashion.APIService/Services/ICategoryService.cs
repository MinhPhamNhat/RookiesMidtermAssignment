
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models;

namespace RookiesFashion.APIService.Services
{
    public interface ICategoryService : IDisposable
    {
        Task<ServiceResponse> GetCategories();
        Task<ServiceResponse> GetCategoryById(int categoryId);
        Task<ServiceResponse> InsertCategory(Category category);
        Task<ServiceResponse> UpdateCategory(Category category);
        Task<ServiceResponse> DeleteCategory(int categoryId);
        bool IsExist(int categoryId);
    }
}