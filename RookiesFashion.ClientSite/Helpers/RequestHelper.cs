using System.Net;
using System.Net.Http.Headers;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.ClientSite.Helpers;

public static class RequestHelper
{
    static HttpClientHandler clientHandler = new HttpClientHandler();

    public static async Task<ServiceResponse> Get(string url)
    {
        try
        {
            HttpResponseMessage respMess = new HttpResponseMessage();
            using (var clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var client = new HttpClient(clientHandler);
                respMess = await client.GetAsync(url);
            }
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

    public static async Task<ServiceResponse> Post(string url, MultipartFormDataContent formData)
    {
        try
        {
            HttpResponseMessage respMess = new HttpResponseMessage();
            using (var clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var client = new HttpClient(clientHandler);
                respMess = await client.PostAsync(url, formData);
            }
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

    public static Task<ServiceResponse> Delete(string url, object data)
    {
        throw new NotImplementedException();
    }

    public static Task<ServiceResponse> Put(string url, object data)
    {
        throw new NotImplementedException();
    }


}