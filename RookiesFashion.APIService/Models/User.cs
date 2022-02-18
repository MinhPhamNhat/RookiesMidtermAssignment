using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RookiesFashion.APIService.Constants;

namespace RookiesFashion.APIService.Models
{
     [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public RoleConstants RoleId { get; set; }
        public virtual Role Role { get; set; }
        public string IdentityUsername { get; set; }
        public virtual Account Identity { get; set; }

    }
}