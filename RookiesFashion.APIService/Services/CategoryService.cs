using Microsoft.EntityFrameworkCore;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.APIService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly RookiesFashionContext _context;

        // private bool disposed = false;

        public CategoryService(RookiesFashionContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse> GetCategories()
        {
            try
            {
                var categories = _context.Categories.Where(c=>c.IsParent).ToList();
                var output = new List<Category>();
                foreach(var category in categories){
                    output.Add(category);
                    output.AddRange(category.Children);
                }

                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.SUCCESS,
                    Message = "Successfully Get Categories",
                    Data = output
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

        public async Task<ServiceResponse> GetCategoryById(int categoryId)
        {
            try
            {
                var category = _context.Categories.Find(categoryId);

                if (category != null)
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseConstants.SUCCESS,
                        Data = category,
                        Message = $"Succesfully Get Category {categoryId}"
                    };
                else
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseConstants.OBJECT_NOT_FOUND,
                        Message = "Category not found"
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

        public async Task<ServiceResponse> InsertCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                
                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.DATA_CREATED,
                    Message = "Category Created",
                    Data = category
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

        public async Task<ServiceResponse> UpdateCategory(Category category)
        {
            try
            {
                _context.Entry(category).State = EntityState.Modified;
                _context.SaveChanges();
                
                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.SUCCESS,
                    Message = "Category Updated",
                    Data = category
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

        public async Task<ServiceResponse> DeleteCategory(int categoryId)
        {
            try
            {
                var category = _context.Categories.Find(categoryId);
                
                if (category != null)
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseConstants.SUCCESS,
                    };
                else
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseConstants.OBJECT_NOT_FOUND,
                        Message = "Category not found"
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

        public bool IsExist(int categoryId)
        {
            return _context.Categories.Any(e => e.CategoryId == categoryId);
        }

        // protected virtual void Dispose(bool disposing)
        // {
        //     if (!this.disposed)
        //     {
        //         if (disposing)
        //         {
        //             _context.Dispose();
        //         }
        //     }
        //     this.disposed = true;
        // }

        // public void Dispose()
        // {
        //     Dispose(true);
        //     GC.SuppressFinalize(this);
        // }

    }
}