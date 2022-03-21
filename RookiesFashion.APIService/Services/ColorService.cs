using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.SharedRepo.Helpers;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.SharedRepo.Extensions;

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
                        Code = ServiceResponseConstants.SUCCESS,
                        Data = color,
                        Message = $"Succesfully Get Color {colorId}"
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
                    RespException = ex
                };
            }
        }

        public async Task<ServiceResponse> GetColors()
        {
            try
            {
                var categories = _context.Colors.ToList();

                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.SUCCESS,
                    Message = "Successfully Get Colors",
                    Data = categories
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

        public List<Color> GetColorsFromRange(List<int> colorIds)
        {
            var listColor = _context.Colors.Where(s=>colorIds.Contains(s.ColorId)).ToList();
            return listColor;
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