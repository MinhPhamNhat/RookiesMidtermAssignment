using System.ComponentModel;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.SharedRepo.Helpers;

public static class ImageHelper
{

    public static async Task<string> SaveToTempPath(IFormFile f)
    {
        var filePath = getImageTempPath();
        using (var stream = System.IO.File.Create(filePath))
        {
            await f.CopyToAsync(stream);
        }
        return filePath;
    }

    public static async Task<ByteArrayContent> convertToByte(IFormFile file)
    {

        var filePath = await SaveToTempPath(file);
        var byteArray = File.ReadAllBytes(filePath);
        var imgData = new ByteArrayContent(byteArray);
        imgData.Headers.Remove("Content-Type");
        imgData.Headers.Add("Content-Type", file.ContentType);
        return imgData;
    }
    public static string getImageTempPath() => Path.GetTempPath() + Guid.NewGuid().ToString() + FunctionsHelper.GetDescription(RequirementConstants.DEFAULT_IMAGE_EXTENSION);
}