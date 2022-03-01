using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.ViewModels;
public class ImageVM
{
    public int ImageId { get; set; }

    public string? ImageName { get; set; }

    public string? Extension { get; set; }

    public string? Url
    {
        get; set;
    }
}
