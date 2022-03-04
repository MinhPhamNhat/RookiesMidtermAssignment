using Microsoft.EntityFrameworkCore;
using RookiesFashion.APIService.Models;
using RookiesFashion.SharedRepo.Constants;

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
                Name = "Topwear",
                Description = "Topwear",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 2,
                Name = "T-Shirts",
                Description = "T-Shirts",
                ParentCategoryId = 1
            },
            new Category()
            {
                CategoryId = 3,
                Name = "Casual Shirts",
                Description = "Casual Shirts",
                ParentCategoryId = 1
            },
            new Category()
            {
                CategoryId = 4,
                Name = "Formal Shirts",
                Description = "Formal Shirts",
                ParentCategoryId = 1
            },
            new Category()
            {
                CategoryId = 5,
                Name = "Sweatshirts",
                Description = "Sweatshirts",
                ParentCategoryId = 1
            },
            new Category()
            {
                CategoryId = 6,
                Name = "Sweaters",
                Description = "Sweaters",
                ParentCategoryId = 1
            },
            new Category()
            {
                CategoryId = 7,
                Name = "Jackets",
                Description = "Jackets",
                ParentCategoryId = 1
            },
            new Category()
            {
                CategoryId = 8,
                Name = "Blazers & Coats",
                Description = "Blazers & Coats",
                ParentCategoryId = 1
            },
            new Category()
            {
                CategoryId = 9,
                Name = "Suits",
                Description = "Suits",
                ParentCategoryId = 1
            },
            new Category()
            {
                CategoryId = 10,
                Name = "Rain Jackets",
                Description = "Rain Jackets",
                ParentCategoryId = 1
            },
            new Category()
            {
                CategoryId = 11,
                Name = "Indian & Festive Wear",
                Description = "Indian & Festive Wear",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 12,
                Name = "Kurtas & Kurta Sets",
                Description = "Kurtas & Kurta Sets",
                ParentCategoryId = 11
            },
            new Category()
            {
                CategoryId = 13,
                Name = "Sherwanis",
                Description = "Sherwanis",
                ParentCategoryId = 11
            },
            new Category()
            {
                CategoryId = 14,
                Name = "Nehru Jackets",
                Description = "Nehru Jackets",
                ParentCategoryId = 11
            },
            new Category()
            {
                CategoryId = 15,
                Name = "Dhotis",
                Description = "Dhotis",
                ParentCategoryId = 11
            },
            new Category()
            {
                CategoryId = 16,
                Name = "Bottomwear",
                Description = "Bottomwear",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 17,
                Name = "Jeans",
                Description = "Jeans",
                ParentCategoryId = 16
            },
            new Category()
            {
                CategoryId = 18,
                Name = "Casual Trousers",
                Description = "Casual Trousers",
                ParentCategoryId = 16
            },
            new Category()
            {
                CategoryId = 19,
                Name = "Formal Trousers",
                Description = "Formal Trousers",
                ParentCategoryId = 16
            },
            new Category()
            {
                CategoryId = 20,
                Name = "Shorts",
                Description = "Shorts",
                ParentCategoryId = 16
            },
            new Category()
            {
                CategoryId = 21,
                Name = "Track Pants & Joggers",
                Description = "Track Pants & Joggers",
                ParentCategoryId = 16
            },
            new Category()
            {
                CategoryId = 22,
                Name = "Innerwear & Sleepwear",
                Description = "Innerwear & Sleepwear",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 23,
                Name = "Briefs & Trunks",
                Description = "Briefs & Trunks",
                ParentCategoryId = 22
            },
            new Category()
            {
                CategoryId = 24,
                Name = "Boxers",
                Description = "Boxers",
                ParentCategoryId = 22
            },
            new Category()
            {
                CategoryId = 25,
                Name = "Vests",
                Description = "Vests",
                ParentCategoryId = 22
            },
            new Category()
            {
                CategoryId = 26,
                Name = "Sleepwear & Loungewear",
                Description = "Sleepwear & Loungewear",
                ParentCategoryId = 22
            },
            new Category()
            {
                CategoryId = 27,
                Name = "Thermals",
                Description = "Thermals",
                ParentCategoryId = 22
            },
            new Category()
            {
                CategoryId = 28,
                Name = "Plus Size",
                Description = "Plus Size",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 29,
                Name = "Footwear",
                Description = "Footwear",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 30,
                Name = "Casual Shoes",
                Description = "Casual Shoes",
                ParentCategoryId = 29
            },
            new Category()
            {
                CategoryId = 31,
                Name = "Sports Shoes",
                Description = "Sports Shoes",
                ParentCategoryId = 29
            },
            new Category()
            {
                CategoryId = 32,
                Name = "Formal Shoes",
                Description = "Formal Shoes",
                ParentCategoryId = 29
            },
            new Category()
            {
                CategoryId = 33,
                Name = "Sneakers",
                Description = "Sneakers",
                ParentCategoryId = 29
            },
            new Category()
            {
                CategoryId = 34,
                Name = "Sandals & Floaters",
                Description = "Sandals & Floaters",
                ParentCategoryId = 29
            },
            new Category()
            {
                CategoryId = 35,
                Name = "Flip Flops",
                Description = "Flip Flops",
                ParentCategoryId = 29
            },
            new Category()
            {
                CategoryId = 36,
                Name = "Socks",
                Description = "Socks",
                ParentCategoryId = 29
            },
            new Category()
            {
                CategoryId = 37,
                Name = "Personal Care & Grooming",
                Description = "Personal Care & Grooming",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 38,
                Name = "Sunglasses & Frames",
                Description = "Sunglasses & Frames",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 39,
                Name = "Watches",
                Description = "Watches",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 40,
                Name = "Sports & Active Wear",
                Description = "Sports & Active Wear",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 41,
                Name = "Sports Shoes",
                Description = "Sports Shoes",
                ParentCategoryId = 40
            },
            new Category()
            {
                CategoryId = 42,
                Name = "Sports Sandals",
                Description = "Sports Sandals",
                ParentCategoryId = 40
            },
            new Category()
            {
                CategoryId = 43,
                Name = "Active T-Shirts",
                Description = "Active T-Shirts",
                ParentCategoryId = 40
            },
            new Category()
            {
                CategoryId = 44,
                Name = "Track Pants & Shorts",
                Description = "Track Pants & Shorts",
                ParentCategoryId = 40
            },
            new Category()
            {
                CategoryId = 45,
                Name = "Tracksuits",
                Description = "Tracksuits",
                ParentCategoryId = 40
            },
            new Category()
            {
                CategoryId = 46,
                Name = "Jackets & Sweatshirts",
                Description = "Jackets & Sweatshirts",
                ParentCategoryId = 40
            },
            new Category()
            {
                CategoryId = 47,
                Name = "Sports Accessories",
                Description = "Sports Accessories",
                ParentCategoryId = 40
            },
            new Category()
            {
                CategoryId = 48,
                Name = "Swimwear",
                Description = "Swimwear",
                ParentCategoryId = 40
            },
            new Category()
            {
                CategoryId = 49,
                Name = "Gadgets",
                Description = "Gadgets",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 50,
                Name = "Smart Wearables",
                Description = "Smart Wearables",
                ParentCategoryId = 49
            },
            new Category()
            {
                CategoryId = 51,
                Name = "Fitness Gadgets",
                Description = "Fitness Gadgets",
                ParentCategoryId = 49
            },
            new Category()
            {
                CategoryId = 52,
                Name = "Headphones",
                Description = "Headphones",
                ParentCategoryId = 49
            },
            new Category()
            {
                CategoryId = 53,
                Name = "Speakers",
                Description = "Speakers",
                ParentCategoryId = 49
            },
            new Category()
            {
                CategoryId = 54,
                Name = "Fashion Accessories",
                Description = "Fashion Accessories",
                IsParent = true
            },
            new Category()
            {
                CategoryId = 55,
                Name = "Wallets",
                Description = "Wallets",
                ParentCategoryId = 54
            },
            new Category()
            {
                CategoryId = 56,
                Name = "Belts",
                Description = "Belts",
                ParentCategoryId = 54
            },
            new Category()
            {
                CategoryId = 57,
                Name = "Perfumes & Body Mists",
                Description = "Perfumes & Body Mists",
                ParentCategoryId = 54
            },
            new Category()
            {
                CategoryId = 58,
                Name = "Trimmers",
                Description = "Trimmers",
                ParentCategoryId = 54
            },
            new Category()
            {
                CategoryId = 59,
                Name = "Deodorants",
                Description = "Deodorants",
                ParentCategoryId = 54
            },
            new Category()
            {
                CategoryId = 60,
                Name = "Ties, Cufflinks & Pocket Squares",
                Description = "Ties, Cufflinks & Pocket Squares",
                ParentCategoryId = 54
            },
            new Category()
            {
                CategoryId = 61,
                Name = "Accessory Gift Sets",
                Description = "Accessory Gift Sets",
                ParentCategoryId = 54
            },
            new Category()
            {
                CategoryId = 62,
                Name = "Caps & Hats",
                Description = "Caps & Hats",
                ParentCategoryId = 54
            },
            new Category()
            {
                CategoryId = 63,
                Name = "Mufflers, Scarves & Gloves",
                Description = "Mufflers, Scarves & Gloves",
                ParentCategoryId = 54
            },
            new Category()
            {
                CategoryId = 64,
                Name = "Phone Cases",
                Description = "Phone Cases",
                ParentCategoryId = 54
            },
            new Category()
            {
                CategoryId = 65,
                Name = "Rings & Wristwear",
                Description = "Rings & Wristwear",
                ParentCategoryId = 54
            },
            new Category()
            {
                CategoryId = 66,
                Name = "Helmets",
                Description = "Helmets",
                ParentCategoryId = 54
            }
        );
        modelBuilder.Entity<Product>().HasData(
            new Product() { ProductId = 1, Name = "Unisex Baby Long Sleeve Bodysuits Set", Description = "Kids grow up so fast. Your little one may still be an infant, but we're sure they're crying for something stylish, comfortable, and eco-friendly. Well, you can satisfy their \"demands\" with this practical, organic Unisex..", Price = 35, CategoryId = 1, CreatedDate = DateTime.Now },
            new Product() { ProductId = 2, Name = "Long Sleeve 3D Printed Black Cat Sweatshirt", Description = "Long Sleeve 3D Printed Black Cat Sweatshirt", Price = 55, CategoryId = 1, CreatedDate = DateTime.Now },
            new Product() { ProductId = 3, Name = "Dreamville Street Wear Sweatshirt", Description = "Look like the super star that you are while rocking this unisex Dreamville Street Wear Sweatshirt! It was made just for you.", Price = 55, CategoryId = 3, CreatedDate = DateTime.Now },
            new Product() { ProductId = 5, Name = "Walnut Wooden Watch", Description = "Get the perfect wooden watch for yourself or a loved one - including a unique engraving in the back! This classic piece will match any outfit. NOTE: This watch is only available in the United States. ", Price = 98, CategoryId = 2, CreatedDate = DateTime.Now }
        );
        modelBuilder.Entity<Image>().HasData(
            new Image() { ImageId = 4, ImageName = "yzsjv9f3zxeam2qrmsa5", Extension = "jpg", ProductId = 1 },
            new Image() { ImageId = 5, ImageName = "qqxtq42ju9u3f7xvqx41", Extension = "jpg", ProductId = 1 },
            new Image() { ImageId = 6, ImageName = "iyfpc8zlmsh3hpwhem8r", Extension = "jpg", ProductId = 2 },
            new Image() { ImageId = 7, ImageName = "wojbmn440oja7afudapp", Extension = "jpg", ProductId = 2 },
            new Image() { ImageId = 8, ImageName = "vjcyk00mvrrhadxdvgev", Extension = "jpg", ProductId = 3 },
            new Image() { ImageId = 9, ImageName = "buomsanrphup1hkzgwkg", Extension = "jpg", ProductId = 3 },
            new Image() { ImageId = 12, ImageName = "anllsn2gzufgiv0s6hgo", Extension = "jpg", ProductId = 5 },
            new Image() { ImageId = 13, ImageName = "oivszjvq5ccl1xsbnous", Extension = "jpg", ProductId = 5 },
            new Image() { ImageId = 1, ImageName = "black_ecjeap", Extension = "png", ProductId = null },
            new Image() { ImageId = 2, ImageName = "red_e8saf2", Extension = "png", ProductId = null },
            new Image() { ImageId = 3, ImageName = "white_s8f0yl", Extension = "png", ProductId = null }
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


        modelBuilder.Entity<Product>().HasMany(p=>p.Colors).WithMany(c=>c.Products).UsingEntity(_=>_.HasData(
            new { ColorsColorId = 1, ProductsProductId = 1 },
            new { ColorsColorId = 1, ProductsProductId = 2 },
            new { ColorsColorId = 1, ProductsProductId = 3 },
            new { ColorsColorId = 1, ProductsProductId = 5 },
            new { ColorsColorId = 2, ProductsProductId = 1 },
            new { ColorsColorId = 2, ProductsProductId = 2 },
            new { ColorsColorId = 2, ProductsProductId = 3 },
            new { ColorsColorId = 2, ProductsProductId = 5 },
            new { ColorsColorId = 3, ProductsProductId = 1 },
            new { ColorsColorId = 3, ProductsProductId = 2 },
            new { ColorsColorId = 3, ProductsProductId = 3 },
            new { ColorsColorId = 3, ProductsProductId = 5 }
        ));


        modelBuilder.Entity<Product>().HasMany(p=>p.Sizes).WithMany(c=>c.Products).UsingEntity(_=>_.HasData(
            new { SizesSizeId = 1, ProductsProductId = 1 },
            new { SizesSizeId = 1, ProductsProductId = 2 },
            new { SizesSizeId = 1, ProductsProductId = 3 },
            new { SizesSizeId = 1, ProductsProductId = 5 },
            new { SizesSizeId = 2, ProductsProductId = 1 },
            new { SizesSizeId = 2, ProductsProductId = 2 },
            new { SizesSizeId = 2, ProductsProductId = 3 },
            new { SizesSizeId = 2, ProductsProductId = 5 },
            new { SizesSizeId = 3, ProductsProductId = 1 },
            new { SizesSizeId = 3, ProductsProductId = 2 },
            new { SizesSizeId = 3, ProductsProductId = 3 },
            new { SizesSizeId = 3, ProductsProductId = 5 }
        ));


    }
}