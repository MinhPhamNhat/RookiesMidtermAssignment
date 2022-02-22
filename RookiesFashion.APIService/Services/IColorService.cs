using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models;

namespace RookiesFashion.APIService.Services
{
    public interface IColorService
    {
        Task<ServiceResponse> GetColors();
        Task<ServiceResponse> GetColorById(int colorId);
        Task<ServiceResponse> InsertColor(Color color);
        Task<ServiceResponse> UpdateColor(Color color);
        Task<ServiceResponse> DeleteColor(int colorId);
        bool IsExist(int colorId, out Color color);
    }
}