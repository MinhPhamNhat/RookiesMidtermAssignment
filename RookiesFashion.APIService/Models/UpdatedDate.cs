using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.APIService.Models
{
    [Table("UpdatedDate")]
    public class UpdatedDate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UpdatedDateId { get; set; }

        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }
}