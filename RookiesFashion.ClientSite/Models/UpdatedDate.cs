using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.Models
{
    public class UpdatedDate
    {
        public int UpdatedDateId { get; set; }

        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public DateTime Time { get; set; }
    }
}