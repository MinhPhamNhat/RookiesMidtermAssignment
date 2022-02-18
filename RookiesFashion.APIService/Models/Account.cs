using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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