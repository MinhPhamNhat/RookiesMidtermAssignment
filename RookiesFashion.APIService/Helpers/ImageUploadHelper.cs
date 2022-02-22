using System.ComponentModel;
using System.Reflection;
using RookiesFashion.APIService.Constants;
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Models;

namespace RookiesFashion.APIService.Helpers;

public class ImageUploadHelper{
    List<Image> images;

    ICloudinaryService _cloudinaryService;
    IImageService _imageService;
    public ImageUploadHelper(ICloudinaryService cloudinaryService, IImageService imageService)
    {
        _cloudinaryService = cloudinaryService;
        _imageService = imageService;  
    }

    public async Task<List<Image>> ImageUpload(List<IFormFile> files){
        images = new List<Image>();  
        foreach (var f in files)
        {
            var filePath = Path.GetTempPath() + Guid.NewGuid().ToString() + Function.GetDescription(SystemRequirements.DEFAULT_IMAGE_EXTENSION);
            using (var stream = System.IO.File.Create(filePath))
            {
                await f.CopyToAsync(stream);
            }

            var imageUploadedResult = await _cloudinaryService.Upload(filePath);
            var image = new Image
            {
                ImageName = imageUploadedResult.OriginalFilename,
                Extension = imageUploadedResult.Format
            };

            var imageSerResp = await _imageService.InsertImage(image);
            if (imageSerResp.Code == ServiceResponseStatus.DATA_CREATED)
            {
                images.Add((Image)imageSerResp.Data);
            }else{
                Console.WriteLine(imageSerResp.Message);
            }
        };
        return images;
    }

}