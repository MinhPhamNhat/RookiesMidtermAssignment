using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RookiesFashion.ClientSite.Models.ViewModels
{
    public class AccountVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}