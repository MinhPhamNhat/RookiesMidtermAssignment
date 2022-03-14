using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.APIService.Models.DTO
{
    public class ImageDTO
    {
        public int ImageId { get; set; }

        public string? ImageName { get; set; }

        public string? Extension { get; set; }

        public string? ImageUrl { get; set; }
    }
}