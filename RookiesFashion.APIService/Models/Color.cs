using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.APIService.Models
{
    [Table("Color")]
    public class Color
    {
        public Color()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColorId { get; set; }
        public string? Name { get; set; }
        public int ThumbnailImageId { get; set; }
        public virtual Image? Thumbnail { get; set; }

        public virtual IEnumerable<Product>? Products { get; set; }
    }
}