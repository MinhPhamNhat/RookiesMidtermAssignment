using RookiesFashion.APIService.Data.Context;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Models.DTO;
using RookiesFashion.APIService.Services.Interfaces;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extensions;

public class AccountService : IAccountService
{
    private readonly RookiesFashionContext _context;

    public AccountService(RookiesFashionContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse> CheckLogin(LoginFormDTO form)
    {
        try
        {
            var checkAccount = _context.Accounts.Any(a =>
                    a.Username.Equals(form.Username) &&
                    a.Password.Equals(form.Password));
            if (checkAccount)
            {
                User user = _context.Users.Where(u => u.Identity.Username.Equals(form.Username)).First();
                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.SUCCESS,
                    Message = "Login Successfully",
                    Data = user
                };
            }
            else
            {
                return new ServiceResponse()
                {
                    Code = ServiceResponseConstants.UNAUTHENTICATED,
                    Message = "Login Fail Successfully",
                };
            }
        }
        catch (Exception ex)
        {
            return new ServiceResponse()
            {
                Code = ServiceResponseConstants.ERROR,
                Message = ex.Message,
                RespException = ex
            };
        }
    }
}