using CloudinaryDotNet.Actions;

namespace RookiesFashion.APIService.Services.Interfaces;
public interface ICloudinaryService
{
    Task<ImageUploadResult> Upload(string imagePath);
    Task<ImageUploadResult> Remove(string imageId);
    string BuildImageUrl(string imageName);
}