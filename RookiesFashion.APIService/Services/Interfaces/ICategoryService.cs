
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Models;
using RookiesFashion.SharedRepo.DTO;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.APIService.Services.Interfaces;
public interface ICategoryService
{
    Task<ServiceResponse> GetCategories();
    Task<ServiceResponse> GetCategoryById(int categoryId);
    Task<ServiceResponse> GetParentCategories();
    Task<ServiceResponse> InsertCategory(Category category);
    Task<ServiceResponse> UpdateCategory(Category category);
    Task<ServiceResponse> DeleteCategory(int categoryId);
    Task<ServiceResponse> GetPagedCategoryFilter(CategoryBaseQueryCriteriaDto baseQueryCriteria, CancellationToken cancellationToken);
    bool IsExist(int categoryId);
}