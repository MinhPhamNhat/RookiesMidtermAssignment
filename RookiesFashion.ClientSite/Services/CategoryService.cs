using RookiesFashion.ClientSite.Helpers;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.ClientSite.Services;
public class CategoryService : ICategoryService
{
    private readonly IConfiguration _config;
    public CategoryService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<ServiceResponse> GetCategories()
    {
        try
        {
            var resp = await RequestHelper.Get($"{_config["Host:api"]}/api/Categories");
            Console.WriteLine($"{_config["Host:api"]}/api/Categories");
            return resp;
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
}