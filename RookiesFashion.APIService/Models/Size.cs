using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.APIService.Models
{
    [Table("Size")]
    public class Size
    {
        public Size()
        {
            this.Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SizeId { get; set; }

        [Required]
        public string Name { get; set;}

        public virtual IEnumerable<Product> Products {get; set;}
    }
}