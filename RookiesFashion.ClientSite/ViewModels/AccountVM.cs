using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RookiesFashion.ClientSite.ViewModels;
public class AccountVM
{
    [Required]
    [Display(Name = "Username")]
    public string? Username { get; set; }
    [Required]
    [Display(Name = "Password")]
    public string? Password { get; set; }
}