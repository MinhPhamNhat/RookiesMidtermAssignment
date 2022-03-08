using System.Net;
using System.Net.Http.Headers;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.ClientSite.Helpers;

public static class HttpClientHelper
{
    static HttpClientHandler clientHandler = new HttpClientHandler();

    public static async Task<ServiceResponse> Get(string uri)
    {
        try
        {
            HttpResponseMessage respMess = new HttpResponseMessage();
            using (var clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var client = new HttpClient(clientHandler);
                respMess = await client.GetAsync(uri);
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

    public static async Task<ServiceResponse> Post(string uri, HttpContent  formData)
    {
        try
        {
            HttpResponseMessage respMess = new HttpResponseMessage();
            using (var clientHandler = new HttpClientHandler())
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                var client = new HttpClient(clientHandler);
                respMess = await client.PostAsync(uri, formData);
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

    public static Task<ServiceResponse> Delete(string uri, object data)
    {
        throw new NotImplementedException();
    }

    public static Task<ServiceResponse> Put(string uri, object data)
    {
        throw new NotImplementedException();
    }


}