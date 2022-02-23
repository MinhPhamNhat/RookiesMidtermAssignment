using CloudinaryDotNet.Actions;
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.APIService.Services.Interfaces;
public interface IImageService
{
    Task<ServiceResponse> GetImages();
    Task<ServiceResponse> GetImageById(int imageId);
    Task<ServiceResponse> InsertImage(Image? image);
    Task<ServiceResponse> UpdateImage(Image image);
    Task<ServiceResponse> DeleteImage(int image);
    bool IsExist(int imageId);
}