using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extensions;

public class RatingService : IRatingService
{

    private readonly IConfiguration _config;
    private readonly IHttpClientService _httpClientService;
    public RatingService(IConfiguration config, IHttpClientService httpClientService)
    {
        _config = config;
        _httpClientService = httpClientService;
    }

    public Task<ServiceResponse> GetPagingRatings(RatingFormVM ratingForm)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse> InsertRating(RatingFormVM ratingForm)
    {
        try
        {
            Console.WriteLine("STATUS " + 1111);
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(ratingForm.Comment), "Comment");
            formData.Add(new StringContent(ratingForm.RatingVal.ToString()), "RatingVal");
            formData.Add(new StringContent(ratingForm.ProductId.ToString()), "ProductId");
            var resp = await _httpClientService.PostAsync($"{_config["Host:api"]}{EndpointConstants.RATINGS}", formData);
            Console.WriteLine("STATUS " + resp.Code);
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