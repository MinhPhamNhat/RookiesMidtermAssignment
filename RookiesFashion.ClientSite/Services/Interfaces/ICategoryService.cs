using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.ClientSite.Services.Interfaces;

public interface ICategoryService
{
    Task<ServiceResponse> GetCategories();
}
