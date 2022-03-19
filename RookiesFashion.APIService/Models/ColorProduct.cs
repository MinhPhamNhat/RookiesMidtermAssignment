using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RookiesFashion.APIService.Models
{
    [Table("ColorProduct")]
    public class ColorProduct
    {
        public int ColorId { get; set; }
        public int ProductId { get; set; }
        public Color Color { get; set; }
        public Product Product { get; set; }
    }
}