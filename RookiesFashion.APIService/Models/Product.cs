
using RookiesFashion.APIService.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.APIService.Models{
    [Table("Product")]
    public class Product{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public virtual IEnumerable<Image> Thumbnail { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        [Required]
        public virtual IEnumerable<Color> Color { get; set; }
        
        [Required]
        public virtual IEnumerable<Size> Size { get; set; }

    }
}