using RookiesFashion.APIService.Constants;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models;

namespace RookiesFashion.APIService.Services
{
    public class ColorService : IColorService
    {
        private readonly RookiesFashionContext _context;
        public ColorService(RookiesFashionContext context)
        {
            _context = context;    
        }
        public Task<ServiceResponse> DeleteColor(int colorId)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse> GetColorById(int colorId)
        {
            try
            {
                var color = _context.Colors.Find(colorId);

                if (color != null)
                    return new ServiceResponse()
                    {
                        Code = ServiceResponseStatus.SUCCESS,
                        Data = color,
                        Message = $"Succesfully Get Color {colorId}"
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

        public Task<ServiceResponse> GetColors()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse> InsertColor(Color color)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int colorId, out Color color)
        {
            color =  _context.Colors.Find(colorId);
            return color != null;
        }

        public Task<ServiceResponse> UpdateColor(Color color)
        {
            throw new NotImplementedException();
        }
    }
}