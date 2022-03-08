using CloudinaryDotNet.Actions;

namespace RookiesFashion.ClientSite.Services.Interfaces;
public interface ICloudinaryService
{
    Task<ImageUploadResult> Upload(string imagePath);
    Task<ImageUploadResult> Remove(string imageId);
    Task<List<Models.Image>> FormFilesUpload(List<IFormFile> files);
    string BuildImageUrl(string imageName);
}