using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.ViewModels;
public class ColorVM
{
    public int ColorId { get; set; }
    public string? Name { get; set; }
    public int ThumbnailImageId { get; set; }
    public ImageVM? Thumbnail { get; set; }
}