using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using RookiesFashion.APIService.Services.Interfaces;

namespace RookiesFashion.APIService.Extension;

public class CloudinaryService : ICloudinaryService
{
    private readonly IConfiguration _config;

    public Cloudinary cloud;

    public CloudinaryService(IConfiguration config)
    {
        _config = config;
        Account account = new Account(_config["Cloudinary:CLOUD_NAME"], _config["Cloudinary:API_KEY"], _config["Cloudinary:API_SECRET"]);
        cloud = new Cloudinary(account);
    }

    public async Task<ImageUploadResult> Upload(string imagePath)
    {
        try
        {
            FileDescription fileDesc = new FileDescription(imagePath);
            var uploadResult = await cloud.UploadAsync(new ImageUploadParams() { File = fileDesc });
            return uploadResult;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<ImageUploadResult> Remove(string imageId)
    {
        throw new NotImplementedException();
    }

    public string BuildImageUrl(string imageName) => cloud.Api.UrlImgUp.Secure(true)
    .Transform(new Transformation().AspectRatio("1.1").Crop("fill_pad")).BuildUrl(imageName);
}