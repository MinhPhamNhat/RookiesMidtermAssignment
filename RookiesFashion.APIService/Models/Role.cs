using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RookiesFashion.APIService.Constants;

namespace RookiesFashion.APIService.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public RoleConstants RoleId { get; set; }
        [Required]
        public string? Description { get; set; }

    }
}