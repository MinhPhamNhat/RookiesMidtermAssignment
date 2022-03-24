using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.APIService.Models
{
     [Table("User")]
    public class User: IdentityUser
    {
        
        public User() : base()
        {
        }

        public User(string userName) : base(userName)
        {
        }

        [Required]
        public string? Name { get; set; }

    }
}