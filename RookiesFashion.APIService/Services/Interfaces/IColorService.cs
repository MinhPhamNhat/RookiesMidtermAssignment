using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.APIService.Services.Interfaces;
public interface IColorService
{
    Task<ServiceResponse> GetColors();
    Task<ServiceResponse> GetColorById(int colorId);
    Task<ServiceResponse> InsertColor(Color color);
    Task<ServiceResponse> UpdateColor(Color color);
    Task<ServiceResponse> DeleteColor(int colorId);
    bool IsExist(int colorId, out Color color);
}