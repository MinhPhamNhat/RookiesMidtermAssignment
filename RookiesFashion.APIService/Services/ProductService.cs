using Microsoft.EntityFrameworkCore;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.SharedRepo.DTO;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models.DTO;

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
                var products = _context.Products.Where(p => !p.IsDeleted).ToList();
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
                var product = _context.Products.Where(p => !p.IsDeleted)
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
                var newUpdatedDate = new UpdatedDate() { ProductId = product.ProductId };
                _context.UpdatedDates.Add(newUpdatedDate);
                var oldProduct = _context.Products.First(p => p.ProductId == product.ProductId);
                oldProduct.Description = product.Description;
                oldProduct.CategoryId = product.CategoryId;
                oldProduct.Price = product.Price;
                if (product.Thumbnail.Count > 0)
                {
                    oldProduct.Thumbnail.Clear();
                    oldProduct.Thumbnail = product.Thumbnail;
                }
                if (product.Colors.Count > 0)
                {
                    oldProduct.Colors.Clear();
                    oldProduct.Colors = product.Colors;
                }
                if (product.Sizes.Count > 0)
                {
                    oldProduct.Sizes.Clear();
                    oldProduct.Sizes = product.Sizes;
                }
                _context.Entry(oldProduct).State = EntityState.Modified;
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
                var product = _context.Products.Where(p => !p.IsDeleted).FirstOrDefault(p => p.ProductId == productId);

                if (product != null)
                {
                    product.IsDeleted = true;
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

        public async Task<ServiceResponse> GetPagedProductFilter(ProductBaseQueryCriteriaDto baseQueryCriteria, CancellationToken cancellationToken)
        {
            try
            {
                var products = _context.Products.Where(p => !p.IsDeleted).AsQueryable();
                products = FilterHelper.ProductFilter(products, baseQueryCriteria);
                var pagedProducts = await products.PaginateAsync(baseQueryCriteria, cancellationToken);
                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.SUCCESS,
                    Message = "Successfully Get Products",
                    Data = pagedProducts
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

        public async Task<ServiceResponse> GetProductWithPagingRating(int productId, RatingBaseQueryCriteriaDto baseQuery, CancellationToken cancellationToken)
        {
            try
            {
                var product = _context.Products.Where(p => !p.IsDeleted).First(p => p.ProductId == productId);
                if (product != null)
                {
                    var tempRatings = _context.Ratings.Where(r => r.ProductId == productId).AsQueryable();
                    var ratings = FilterHelper.RatingFilter(tempRatings, baseQuery);
                    var pagedRatings = await ratings.PaginateAsync(baseQuery, cancellationToken);

                    List<int> countRating = new List<int>();
                    List<double> countPercentage = new List<double>();
                    for(var i = 1; i <= 5; i++){
                        var ratingVal = tempRatings.Where(r => r.RatingVal == i);
                        var count = ratingVal.Count();
                        countRating.Add(count);
                        var percentage = (double)count/tempRatings.Count()*100;
                        countPercentage.Add(percentage);
                    } 

                    var productDetailwithRating = new ProductDetailDTO { Product = product, PagedRating = pagedRatings, CountRating = countRating, CountPercentage = countPercentage };
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseConstants.SUCCESS,
                        Message = "Successfully Get Products",
                        Data = productDetailwithRating
                    };
                }
                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.OBJECT_NOT_FOUND,
                    Message = "Product not found",
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
    }
}