using RookiesFashion.ClientSite.ViewModels;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.ClientSite.Services.Interfaces;

public interface IAccountService
{
    Task<ServiceResponse> Login(AccountVM account);
    Task<ServiceResponse> Register(AccountVM account);
}
