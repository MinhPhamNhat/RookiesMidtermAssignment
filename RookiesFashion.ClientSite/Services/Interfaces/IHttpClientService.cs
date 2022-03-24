using RookiesFashion.SharedRepo.Extensions;
namespace RookiesFashion.ClientSite.Services.Interfaces;
public interface IHttpClientService {
    public Task<ServiceResponse> GetAsync(string uri);
    public Task<ServiceResponse> PostAsync(string uri, HttpContent  formData);
}