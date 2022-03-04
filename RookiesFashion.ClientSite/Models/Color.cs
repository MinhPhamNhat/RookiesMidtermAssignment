using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string? Name { get; set; }
        public int ThumbnailImageId { get; set; }
        public Image? Thumbnail { get; set; }
    }
}