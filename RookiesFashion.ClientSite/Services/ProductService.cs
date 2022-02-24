using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.ClientSite.Services;
using Newtonsoft.Json;

namespace RookiesFashion.APIService.Services
{
    public class ProductService : IProductService
    {

        private readonly IConfiguration _config;
        public ProductService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<ServiceResponse> GetProducts()
        {
            try
            {
                var resp = await Repository.Get($"{_config["Host:api"]}/api/Products");
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

        public async Task<ServiceResponse> GetProductById(int productId)
        {
            try
            {
                var resp = await Repository.Get($"{_config["Host:api"]}/api/Products/{productId}");
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

        public async Task<ServiceResponse> InsertProduct(Dictionary<string, object> payload,List<IFormFile> files)
        {
            try
            {
                var resp = await Repository.Post($"{_config["Host:api"]}/api/Products", new List<KeyValuePair<string, string>> {
                    new KeyValuePair<string, string>("data", JsonConvert.SerializeObject(payload))
                });
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

        public async Task<ServiceResponse> UpdateProduct(Product product)
        {
            try
            {
                throw new NotImplementedException();

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

        public async Task<ServiceResponse> DeleteProduct(int productId)
        {
            try
            {
                throw new NotImplementedException();

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

        public bool IsExist(int productId, out Product product)
        {
            throw new NotImplementedException();
        }

    }
}