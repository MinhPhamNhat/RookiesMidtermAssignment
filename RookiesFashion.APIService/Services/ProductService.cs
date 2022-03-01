using Microsoft.EntityFrameworkCore;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.SharedRepo.Helpers;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.APIService.Services
{
    public class ProductService : IProductService
    {
        private readonly RookiesFashionContext _context;


        public ProductService(RookiesFashionContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> GetProducts()
        {
            try
            {
                var products = _context.Products.ToList();

                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.SUCCESS,
                    Message = "Successfully Get Products",
                    Data = products
                };
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
                var product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(c => c.Parent)
                .FirstOrDefault(p => p.ProductId == productId);

                if (product != null)
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseConstants.SUCCESS,
                        Data = product,
                        Message = $"Succesfully Get Product {productId}"
                    };
                else
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseConstants.OBJECT_NOT_FOUND,
                        Message = "Product not found"
                    };

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

        public async Task<ServiceResponse> InsertProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.DATA_CREATED,
                    Message = "Product Created",
                    Data = product
                };

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
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();

                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.SUCCESS,
                    Message = "Product Updated",
                    Data = product
                };

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
                var product = _context.Products.FirstOrDefault(p=>p.ProductId==productId);

                if (product != null)
                {   
                    _context.Images.RemoveRange(product.Thumbnail);
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseConstants.SUCCESS,
                        Message = $"Successfully Delete Product {productId}"
                    };
                }
                else
                {
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseConstants.OBJECT_NOT_FOUND,
                        Message = "Product not found"
                    };
                }

            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.ERROR,
                    Message = ex.StackTrace,
                    RespException = ex
                };
            }
        }

        public bool IsExist(int productId, out Product product)
        {
            product = _context.Products.Find(productId);
            return product != null;
        }

    }
}