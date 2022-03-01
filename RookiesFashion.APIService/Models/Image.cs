using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}