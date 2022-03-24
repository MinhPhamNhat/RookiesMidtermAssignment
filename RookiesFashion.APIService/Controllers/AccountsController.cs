#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Models.DTO;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extensions;
using RookiesFashion.SharedRepo.Helpers;

namespace RookiesFashion.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly RookiesFashionContext _context;
        private readonly IAccountService _accountService;

        public AccountsController(RookiesFashionContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var users = _context.Users.ToList();
            ServiceResponse serResp = new ServiceResponse{
                Message = "Successfully get users",
                Code = ServiceResponseConstants.SUCCESS,
                Data = users
            };
            return MyApiHelper.RequestResultParser(serResp, HttpContext);
        }


    }
}
