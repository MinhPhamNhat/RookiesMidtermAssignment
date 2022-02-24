using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.ClientSite.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public RoleConstants RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public string? IdentityUsername { get; set; }
        public virtual Account? Identity { get; set; }

    }
}