using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.APIService.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [Column("Username")]
        public string Username { get; set; }

        [Required] 
        [JsonIgnore]   
        public string Password { get; set; }
    }
}