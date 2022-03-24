using System.ComponentModel.DataAnnotations;

namespace RookiesFashion.APIService.ViewModels.CustomAuthentication
{
    public class RegisterAuthModelVM
    {
        [Required]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        public string ReturnUrl { get; set; }
    }
}