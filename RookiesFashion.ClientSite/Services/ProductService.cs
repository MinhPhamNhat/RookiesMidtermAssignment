using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.ClientSite.Services;
using Newtonsoft.Json;
using System.Text;
using RookiesFashion.SharedRepo.Helpers;
using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.DTO;

namespace RookiesFashion.ClientSite.Services
{
    public class ProductService : IProductService
    {

        private readonly IConfiguration _config;
        private readonly IHttpClientService _httpClientService;
        public ProductService(IConfiguration config, IHttpClientService httpClientService)
        {
            _config = config;
            _httpClientService = httpClientService;
        }

        public async Task<ServiceResponse> GetProducts()
        {
            try
            {
                
                var resp = await _httpClientService.GetAsync($"{_config["Host:api"]}{EndpointConstants.PRODUCTS}");
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

        public async Task<ServiceResponse> GetProductById(int productId, RatingBaseQueryCriteriaDto query)
        {
            try
            {
                var uri = QueryHelper.parseQuery($"{_config["Host:api"]}{EndpointConstants.PRODUCTS}/Detail/{productId}", query);
                var resp = await _httpClientService.GetAsync(uri);
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

        public Task<ServiceResponse> GetProductByCategoryId(string categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> InsertProduct(Product dataModel, List<IFormFile> files)
        {
            try
            {
                ServiceResponse resp = new ServiceResponse();
                using (var formData = new MultipartFormDataContent())
                {
                    foreach (var file in files)
                    {
                        var imgData = await ImageHelper.convertToByte(file);
                        formData.Add(imgData, "Files", file.FileName);
                    }
                    formData.Add(new StringContent(JsonConvert.SerializeObject(dataModel), Encoding.UTF8));
                    resp = await _httpClientService.PostAsync($"{_config["Host:api"]}{EndpointConstants.PRODUCTS}", formData);
                }
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
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> GetProductsByQuery(ProductBaseQueryCriteriaDto query)
        {
            try
            {
                var uri = QueryHelper.parseQuery($"{_config["Host:api"]}{EndpointConstants.PRODUCTS}", query);
                var resp = await _httpClientService.GetAsync(uri);
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

        // public async Task<ServiceResponse> UpdateProduct(Product product)
        // {
        //     try
        //     {
        //         throw new NotImplementedException();

        //     }
        //     catch (Exception ex)
        //     {
        //         return new ServiceResponse()
        //         {
        //             Code = ServiceResponseConstants.ERROR,
        //             Message = ex.Message,
        //             RespException = ex
        //         };
        //     }
        // }

        // public async Task<ServiceResponse> DeleteProduct(int productId)
        // {
        //     try
        //     {
        //         throw new NotImplementedException();

        //     }
        //     catch (Exception ex)
        //     {
        //         return new ServiceResponse()
        //         {
        //             Code = ServiceResponseConstants.ERROR,
        //             Message = ex.Message,
        //             RespException = ex
        //         };
        //     }
        // }

        // public bool IsExist(int productId, out Product product)
        // {
        //     throw new NotImplementedException();
        // }

        // public bool IsExist(int productId, out Product product)
        // {
        //     throw new NotImplementedException();
        // }

    }
}