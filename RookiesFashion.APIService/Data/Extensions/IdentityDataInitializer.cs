using Microsoft.AspNetCore.Identity;
using RookiesFashion.APIService.Models;
using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.APIService.Data.Extensions
{
    public static class IdentityDataInitializer
    {
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync(SecurityConstants.USER_ROLE).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = SecurityConstants.USER_ROLE;
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync(SecurityConstants.ADMINISTRATION_ROLE).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = SecurityConstants.ADMINISTRATION_ROLE;
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }

        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("user1").Result == null)
            {
                User user = new User();
                user.UserName = "user1";
                user.Name = "User 1";
                user.Email = "user1@gmail.com";

                IdentityResult result = userManager.CreateAsync(user, "User@123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,SecurityConstants.USER_ROLE).Wait();
                }
            }
            if (userManager.FindByNameAsync("user2").Result == null)
            {
                User user = new User();
                user.UserName = "user2";
                user.Name = "User 2";
                user.Email = "user2@gmail.com";

                IdentityResult result = userManager.CreateAsync(user, "User@123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,SecurityConstants.USER_ROLE).Wait();
                }
            }



            if (userManager.FindByNameAsync("admin").Result == null)
            {
                User user = new User();
                user.UserName = "admin";
                user.Name = "Administrator";
                user.Email = "admin@gmail.com";

                IdentityResult result = userManager.CreateAsync(user, "Admin@123").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user,SecurityConstants.ADMINISTRATION_ROLE).Wait();
                }
            }
        }
    }
}