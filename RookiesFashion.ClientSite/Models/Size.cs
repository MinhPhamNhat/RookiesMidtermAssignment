using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.Models
{
    public class Size
    {
        public int SizeId { get; set; }

        [Required]
        public string Name { get; set;}

        public IEnumerable<Product> Products {get; set;}
    }
}