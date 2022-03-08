using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.ClientSite.ViewModels
{
    public class UserVM
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public RoleConstants RoleId { get; set; }
        public RoleVM? Role { get; set; }
        public string? IdentityUsername { get; set; }
        public AccountVM? Identity { get; set; }

    }
}