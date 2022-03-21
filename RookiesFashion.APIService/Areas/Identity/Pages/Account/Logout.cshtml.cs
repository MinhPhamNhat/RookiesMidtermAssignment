using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RookiesFashion.APIService.Models;

namespace RookiesFashion.APIService.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly IIdentityServerInteractionService _interaction;

        public LogoutModel(
            SignInManager<User> signInManager, 
            ILogger<LogoutModel> logger,
            IIdentityServerInteractionService interactionService
            )
        {
            _signInManager = signInManager;
            _logger = logger;
            _interaction = interactionService;
        }

        // public void OnGet()
        // {
        // }
        public async Task<IActionResult> OnGet(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interaction.GetLogoutContextAsync(logoutId);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
