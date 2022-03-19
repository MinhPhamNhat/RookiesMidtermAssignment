using Microsoft.EntityFrameworkCore;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.SharedRepo.DTO;
using RookiesFashion.APIService.Helpers;

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
                var products = _context.Products.Where(p=>!p.IsDeleted).ToList();
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
                var product = _context.Products.Where(p=>!p.IsDeleted)
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
                var product = _context.Products.Where(p=>!p.IsDeleted).FirstOrDefault(p => p.ProductId == productId);

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

        public async Task<ServiceResponse> GetPagedProductFilter(BaseQueryCriteriaDTO baseQueryCriteria, CancellationToken cancellationToken)
        {
            try
            {
                var products = _context.Products.Where(p=>!p.IsDeleted).AsQueryable();
                products = ProductFilter(products, baseQueryCriteria);
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

        private IQueryable<Product> ProductFilter(
            IQueryable<Product> productQuery,
            BaseQueryCriteriaDTO baseQueryCriteriaDto)
        {
            if (baseQueryCriteriaDto.CategoryId != null && baseQueryCriteriaDto.CategoryId > 0)
                productQuery = productQuery.Where(p =>
                p.CategoryId == baseQueryCriteriaDto.CategoryId ||
                p.Category.ParentCategoryId == baseQueryCriteriaDto.CategoryId);
            if (baseQueryCriteriaDto.Rating != null && baseQueryCriteriaDto.Rating > 0)
                productQuery = productQuery.Where(p => p.Ratings.Select(r => r.RatingVal).Average() >= baseQueryCriteriaDto.Rating);
            if (!string.IsNullOrEmpty(baseQueryCriteriaDto.Search))
                productQuery = productQuery.Where(p => p.Name.ToLower().Contains(baseQueryCriteriaDto.Search.ToLower()));
            productQuery = FilterHelper.ParseProductOrder(productQuery, baseQueryCriteriaDto.SortOrder);
            return productQuery;
        }
    }
}