using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RookiesFashion.APIService.Extension.AppsettingsJson;

namespace RookiesFashion.APIService.Models
{
    [Table("Image")]
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }

        public string? ImageName { get; set; }

        public string? Extension { get; set; }
        public string? ImageUrl {get=> CloudinaryImageHelper.GetImageUrl(ImageName);}
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}