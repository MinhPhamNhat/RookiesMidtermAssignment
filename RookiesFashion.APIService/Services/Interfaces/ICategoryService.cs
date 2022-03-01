
using RookiesFashion.SharedRepo.Helpers;
using RookiesFashion.APIService.Models;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.APIService.Services.Interfaces;
public interface ICategoryService
{
    Task<ServiceResponse> GetCategories();
    Task<ServiceResponse> GetCategoryById(int categoryId);
    Task<ServiceResponse> InsertCategory(Category category);
    Task<ServiceResponse> UpdateCategory(Category category);
    Task<ServiceResponse> DeleteCategory(int categoryId);
    bool IsExist(int categoryId);
}