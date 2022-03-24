using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.ClientSite.Services;

public class HttpClientService : IHttpClientService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IHttpClientFactory _clientFactory;
    public HttpClientService(IHttpContextAccessor httpContextAccessor, IHttpClientFactory clientFactory)
    {
        _httpContextAccessor = httpContextAccessor;
        _clientFactory = clientFactory;

    }


    public async Task<ServiceResponse> GetAsync(string uri)
    {
        try
        {
            var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var respMess = await client.GetAsync(uri);
            return await MyApiHelper.ReadApiResponse(respMess);
        }
        catch (Exception ex)
        {
            return new ServiceResponse
            {
                Code = ServiceResponseConstants.ERROR,
                RespException = ex
            };
        }
    }

    public async Task<ServiceResponse> PostAsync(string uri, HttpContent formData)
    {
        try
        {

            var client = _clientFactory.CreateClient(ServiceConstants.BACK_END_NAMED_CLIENT);
            var respMess = await client.PostAsync(uri, formData);
            return await MyApiHelper.ReadApiResponse(respMess);
        }
        catch (Exception ex)
        {
            return new ServiceResponse
            {
                Code = ServiceResponseConstants.ERROR,
                RespException = ex
            };
        }
    }
}