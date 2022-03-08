using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RookiesFashion.ClientSite.Models;
using RookiesFashion.ClientSite.Services.Interfaces;
using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.DTO;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.ClientSite.Pages.Login;
public class IndexPageModel : PageModel
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;
    private readonly ILogger<IndexPageModel> _logger;
    public IndexPageModel(ILogger<IndexPageModel> logger, IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
        _logger = logger;
    }

    [BindProperty(SupportsGet = true)]
    public AccountVM currentLogin { get; set; }
    public string Message { get; set; }
    public void OnGet()
    {

    }
    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var accountResp = await _accountService.Login(currentLogin);
        if (accountResp.Code == ServiceResponseConstants.SUCCESS)
        {
            return Redirect("/");
        }
        else
        {
            Message = accountResp.Message;
            return Page();
        }
    }

}