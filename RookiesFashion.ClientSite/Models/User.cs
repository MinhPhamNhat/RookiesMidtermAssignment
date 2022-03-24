using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.ClientSite.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? IdentityUsername { get; set; }
        public Account? Identity { get; set; }

    }
}