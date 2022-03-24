using Microsoft.AspNetCore.Authorization;

namespace RookiesFashion.SharedRepo.Security.Authorization.Requirements
{
    public class AdminRoleRequirement : IAuthorizationRequirement
    {
        public AdminRoleRequirement() {
            
        }
    }
}
