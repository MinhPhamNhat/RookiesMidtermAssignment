using RookiesFashion.SharedRepo.Helpers;
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
    List<Color> GetColorsFromRange(List<int> colorIds);
    bool IsExist(int colorId, out Color color);
}