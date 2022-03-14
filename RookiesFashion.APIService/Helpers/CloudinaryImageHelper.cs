using CloudinaryDotNet;
using RookiesFashion.APIService.Extension.AppsettingsJson;

public static class CloudinaryImageHelper
{
    public static string GetImageUrl(string imageName)
    {
        var config = AppSettingsJson.GetAppSettings();
        Account account = new Account(config["Cloudinary:CLOUD_NAME"], config["Cloudinary:API_KEY"], config["Cloudinary:API_SECRET"]);
        Cloudinary cloud = new Cloudinary(account);
        return cloud.Api.UrlImgUp.Secure(true)
        .Transform(new Transformation().AspectRatio("1.0").Crop("pad").Background("auto")).BuildUrl(imageName);
    }
}