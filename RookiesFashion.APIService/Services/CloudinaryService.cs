using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace RookiesFashion.APIService.Extension;

public class CloudinaryService : ICloudinaryService
{
    private readonly string CLOUD_NAME = "drducnod6";
    private readonly string API_KEY = "741689971444553";
    private readonly string API_SECRET = "8Amu1jejy0s7ssEQa8t1sRmuK5g";

    public Cloudinary cloud;

    public CloudinaryService()
    {
        Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);

        cloud = new Cloudinary(account);
    }

    public async Task<ImageUploadResult> Upload(string imagePath)
    {
        try
        {
            FileDescription fileDesc = new FileDescription(imagePath);
            var uploadResult = await cloud.UploadAsync(new ImageUploadParams() {File = fileDesc});
            return uploadResult;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<ImageUploadResult> Remove(string imageId){
        throw new NotImplementedException();
    }

    public string BuildImageUrl(){
        var url = cloud.Api.UrlImgUp.Secure(true).Transform(new Transformation().Angle(90)).BuildUrl("zyj7s0cz1ftixk4k9ja8.jpg");
        return url;
    }
}