using System.Text;
using Newtonsoft.Json;
using RookiesFashion.ClientSite.Helpers;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.ClientSite.Services;
public class AccountService : IAccountService
{
    private readonly IConfiguration _config;

    public AccountService(IConfiguration config)
    {
        _config = config;
    }
    public async Task<ServiceResponse> Login(AccountVM account)
    {
        try
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(account.Username), "Username");
            formData.Add(new StringContent(account.Password), "Password");
            var resp = await HttpClientHelper.Post($"{_config["Host:api"]}{EndpointConstants.ACCOUNTS}/Login", formData);
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

    public Task<ServiceResponse> Register(AccountVM account)
    {
        throw new NotImplementedException();
    }
    private Dictionary<string, TValue> ToDictionary<TValue>(object obj)
    {
        var json = JsonConvert.SerializeObject(obj);
        var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);
        return dictionary;
    }
}