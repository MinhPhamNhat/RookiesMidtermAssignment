using RookiesFashion.APIService.Constants;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Helpers;
using RookiesFashion.APIService.Models;

namespace RookiesFashion.APIService.Services;

public class ImageService : IImageService
{
    RookiesFashionContext _context;
    public ImageService(RookiesFashionContext context)
    {
        _context = context;
    }
    public Task<ServiceResponse> DeleteImage(int image)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse> GetImageById(int imageId)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse> GetImages()
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse> InsertImage(Image image)
    {
        try
        {
            _context.Images.Add(image);
            _context.SaveChanges();

            return new ServiceResponse()
            {
                Code = ServiceResponseStatus.DATA_CREATED,
                Message = "Category Created",
                Data = image
            };

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            return new ServiceResponse()
            {
                Code = ServiceResponseStatus.ERROR,
                Message = ex.Message,
                RespException = ex.InnerException
            };
        }
    }

    public Task<ServiceResponse> InsertImages(List<Image> images)
    {
        throw new NotImplementedException();
    }
    public bool IsExist(int imageId)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse> UpdateImage(Image image)
    {
        throw new NotImplementedException();
    }
}