using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        public string? ImageName { get; set; }

        public string? Extension { get; set; }
    }
}