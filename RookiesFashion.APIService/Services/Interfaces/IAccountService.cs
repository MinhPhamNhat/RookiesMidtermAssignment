
using RookiesFashion.APIService.Extension;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Models.DTO;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.APIService.Services.Interfaces;
public interface IAccountService
{
    Task<ServiceResponse> CheckLogin(LoginFormDTO form);
}