using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RookiesFashion.APIService.Models
{
    [Table("ProductSize")]
    public class ProductSize
    {

        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        [Key, Column(Order = 2)]
        public int SizeId { get; set; }
        public  Size Size { get; set; }
        public  Product Product { get; set; }
    }
}