using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.ClientSite.Services;
public class CategoryService : ICategoryService
{
    private readonly IConfiguration _config;
        private readonly IHttpClientService _httpClientService;
    public CategoryService(IConfiguration config, IHttpClientService httpClientService)
    {
        _config = config;
        _httpClientService = httpClientService;
    }

    public async Task<ServiceResponse> GetCategories()
    {
        try
        {
            var resp = await _httpClientService.GetAsync($"{_config["Host:api"]}{EndpointConstants.CATEGORIES}");
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