using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace RookiesFashion.APIService.ViewModels.CustomAuthentication
{
    public class LoginAuthModelVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public IEnumerable<AuthenticationScheme> ExternalProviders { get; set; }
    }
}