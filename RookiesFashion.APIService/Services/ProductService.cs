using Microsoft.EntityFrameworkCore;
using RookiesFashion.APIService.Constants;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models;

namespace RookiesFashion.APIService.Services
{
    public class ProductService : IProductService, IDisposable
    {
        private readonly RookiesFashionContext _context;

        private bool disposed = false;

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
                    RespException = ex.InnerException
                };
            }
        }

        public async Task<ServiceResponse> GetProductById(int productId)
        {
            try
            {
                var product = _context.Products
                .FirstOrDefault(p=>p.ProductId == productId);

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
                    RespException = ex.InnerException
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
                    RespException = ex.InnerException
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
                    RespException = ex.InnerException
                };
            }
        }

        public async Task<ServiceResponse> DeleteProduct(int productId)
        {
            try
            {
                var product = _context.Products.Find(productId);
                
                if (product != null)
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseConstants.SUCCESS,
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
                    RespException = ex.InnerException
                };
            }
        }

        public bool IsExist(int productId, out Product product)
        {
            product = _context.Products.Find(productId); 
            return product != null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}