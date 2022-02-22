using Microsoft.EntityFrameworkCore;
using RookiesFashion.APIService.Constants;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models;

namespace RookiesFashion.APIService.Services
{
    public class CategoryService : ICategoryService, IDisposable
    {
        private readonly RookiesFashionContext _context;

        private bool disposed = false;

        public CategoryService(RookiesFashionContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> GetCategories()
        {
            try
            {
                var categories = _context.Categories
                .Include(c=>c.Products).ThenInclude(p=>p.Thumbnail)
                .Include(c=>c.Parent).ToList();

                return new ServiceResponse()
                {
                    Code = ServiceResponseStatus.SUCCESS,
                    Message = "Successfully Get Categories",
                    Data = categories
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    Code = ServiceResponseStatus.ERROR,
                    Message = ex.Message,
                    RespException = ex.InnerException
                };
            }
        }

        public async Task<ServiceResponse> GetCategoryById(int categoryId)
        {
            try
            {
                var category = _context.Categories.Find(categoryId);

                if (category != null)
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseStatus.SUCCESS,
                        Data = category,
                        Message = $"Succesfully Get Category {categoryId}"
                    };
                else
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseStatus.OBJECT_NOT_FOUND,
                        Message = "Category not found"
                    };

            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    Code = ServiceResponseStatus.ERROR,
                    Message = ex.Message,
                    RespException = ex.InnerException
                };
            }
        }

        public async Task<ServiceResponse> InsertCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                
                return new ServiceResponse()
                {
                    Code = ServiceResponseStatus.DATA_CREATED,
                    Message = "Category Created",
                    Data = category
                };

            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    Code = ServiceResponseStatus.ERROR,
                    Message = ex.Message,
                    RespException = ex.InnerException
                };
            }
        }

        public async Task<ServiceResponse> UpdateCategory(Category category)
        {
            try
            {
                _context.Entry(category).State = EntityState.Modified;
                _context.SaveChanges();
                
                return new ServiceResponse()
                {
                    Code = ServiceResponseStatus.SUCCESS,
                    Message = "Category Updated",
                    Data = category
                };

            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    Code = ServiceResponseStatus.ERROR,
                    Message = ex.Message,
                    RespException = ex.InnerException
                };
            }
        }

        public async Task<ServiceResponse> DeleteCategory(int categoryId)
        {
            try
            {
                var category = _context.Categories.Find(categoryId);
                
                if (category != null)
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseStatus.SUCCESS,
                    };
                else
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseStatus.OBJECT_NOT_FOUND,
                        Message = "Category not found"
                    };

            }
            catch (Exception ex)
            {
                return new ServiceResponse()
                {
                    Code = ServiceResponseStatus.ERROR,
                    Message = ex.Message,
                    RespException = ex.InnerException
                };
            }
        }

        public bool IsExist(int categoryId)
        {
            return _context.Categories.Any(e => e.CategoryId == categoryId);
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