using Microsoft.EntityFrameworkCore;
using RookiesFashion.APIService.Models;
using RookiesFashion.APIService.Constants;
namespace RookiesFashion.APIService.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Role>().HasData(
            new Role()
            {
                RoleId = RoleConstants.ADMIN_ROLE,
                Description = "Administrator"
            },
            new Role()
            {
                RoleId = RoleConstants.USER_ROLE,
                Description = "User"
            }
        );

        modelBuilder.Entity<Account>().HasData(
            new Account()
            {
                Username = "ADMIN",
                Password = "ADMIN"
            },
            new Account()
            {
                Username = "User1",
                Password = "rookies_user1"
            },
            new Account()
            {
                Username = "User2",
                Password = "rookies_user2"
            }
        );

        modelBuilder.Entity<User>().HasData(
            new User()
            {
                UserId = 1,
                Name = "ADMIN",
                RoleId = RoleConstants.ADMIN_ROLE,
                IdentityUsername = "ADMIN"
            },
            new User()
            {
                UserId = 2,
                Name = "Rookies User 1",
                RoleId = RoleConstants.USER_ROLE,
                IdentityUsername = "User1"
            },
            new User()
            {
                UserId = 3,
                Name = "Rookies User 2",
                RoleId = RoleConstants.USER_ROLE,
                IdentityUsername = "User2"
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                CategoryId = 1,
                Name = "Áo",
                Description = "Áo",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 2,
                Name = "Áo khoác",
                Description = "Áo khoác",
                ParentCategoryId = 1
            },
            new Category()
            {
                CategoryId = 3,
                Name = "Áo Hoodie",
                Description = "Áo Hoodie",
                ParentCategoryId = 1
            },
            new Category()
            {
                CategoryId = 4,
                Name = "Áo Hoodie",
                Description = "Áo Thun",
                ParentCategoryId = 1
            }
        );

        modelBuilder.Entity<Image>().HasData(
            new Image(){
                ImageId = 1,
                ImageName = "black_ecjeap",
                Extension = "png"
            }, 
            new Image(){
                ImageId = 2,
                ImageName = "red_e8saf2",
                Extension = "png"
            },
            new Image(){
                ImageId = 3,
                ImageName = "white_s8f0yl",
                Extension = "png"
            }
        );

        modelBuilder.Entity<Color>().HasData(
            new Color()
            {
                ColorId = 1,
                Name = "Black",
                ThumbnailImageId = 1
            },
            new Color()
            {
                ColorId = 2,
                Name = "Red",
                ThumbnailImageId = 2
            },
            new Color()
            {
                ColorId = 3,
                Name = "White",
                ThumbnailImageId = 3
            }
        );

        modelBuilder.Entity<Size>().HasData(
            new Size()
            {
                SizeId = 1,
                Name = "XL",
            },
            new Size()
            {
                SizeId = 2,
                Name = "XXL"
            },
            new Size()
            {
                SizeId = 3,
                Name = "L"
            }
        );
    }
}