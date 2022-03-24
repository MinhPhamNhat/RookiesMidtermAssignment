using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.ClientSite.Services;

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

    public async Task<List<Models.Image>> FormFilesUpload(List<IFormFile> files)
    {
        List<Models.Image> imageList = new List<Models.Image>();
        foreach (var f in files)
        {
            var filePath = await ImageHelper.SaveToTempPath(f);
            var imageUploadedResult = await this.Upload(filePath);
            var image = new Models.Image
            {
                ImageName = imageUploadedResult.PublicId,
                Extension = imageUploadedResult.Format
            };
            imageList.Add(image);
        }
        return imageList;
    }
    public string BuildImageUrl(string imageName) => cloud.Api.UrlImgUp.Secure(true)
    .Transform(new Transformation().AspectRatio("1.0").Crop("pad").Background("auto")).BuildUrl(imageName);

    Task<List<ClientSite.Models.Image>> ICloudinaryService.FormFilesUpload(List<IFormFile> files)
    {
        throw new NotImplementedException();
    }
}