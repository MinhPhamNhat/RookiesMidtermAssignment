using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Extension;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.APIService.Services.Interfaces;
public interface ISizeService
{
    Task<ServiceResponse> GetSizes();
    Task<ServiceResponse> GetSizeById(int sizeId);
    Task<ServiceResponse> InsertSize(Size size);
    Task<ServiceResponse> UpdateSize(Size size);
    Task<ServiceResponse> DeleteSize(int sizeId);
    bool IsExist(int sizeId, out Size size);
}