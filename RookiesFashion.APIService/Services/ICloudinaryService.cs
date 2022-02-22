using CloudinaryDotNet.Actions;

namespace RookiesFashion.APIService.Extension;

public interface ICloudinaryService
{
    Task<ImageUploadResult> Upload(string imagePath);
    Task<ImageUploadResult> Remove(string imageId);
    string BuildImageUrl();
}