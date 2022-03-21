using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookiesFashion.APIService.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsParent = table.Column<bool>(type: "bit", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    SizesSizeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize", x => new { x.ProductsProductId, x.SizesSizeId });
                    table.ForeignKey(
                        name: "FK_ProductSize_Product_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSize_Size_SizesSizeId",
                        column: x => x.SizesSizeId,
                        principalTable: "Size",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingVal = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserRating = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Rating_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UpdatedDate",
                columns: table => new
                {
                    UpdatedDateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdatedDate", x => x.UpdatedDateId);
                    table.ForeignKey(
                        name: "FK_UpdatedDate_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailImageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.ColorId);
                    table.ForeignKey(
                        name: "FK_Color_Image_ThumbnailImageId",
                        column: x => x.ThumbnailImageId,
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColorProduct",
                columns: table => new
                {
                    ColorsColorId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorProduct", x => new { x.ColorsColorId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_ColorProduct_Color_ColorsColorId",
                        column: x => x.ColorsColorId,
                        principalTable: "Color",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ColorProduct_Product_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "IsDeleted", "IsParent", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Topwear", false, true, "Topwear", null },
                    { 11, "Indian & Festive Wear", false, true, "Indian & Festive Wear", null },
                    { 16, "Bottomwear", false, true, "Bottomwear", null },
                    { 22, "Innerwear & Sleepwear", false, true, "Innerwear & Sleepwear", null },
                    { 28, "Plus Size", false, true, "Plus Size", null },
                    { 29, "Footwear", false, true, "Footwear", null },
                    { 37, "Personal Care & Grooming", false, true, "Personal Care & Grooming", null },
                    { 38, "Sunglasses & Frames", false, true, "Sunglasses & Frames", null },
                    { 39, "Watches", false, true, "Watches", null },
                    { 40, "Sports & Active Wear", false, true, "Sports & Active Wear", null },
                    { 49, "Gadgets", false, true, "Gadgets", null },
                    { 54, "Fashion Accessories", false, true, "Fashion Accessories", null }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "Extension", "ImageName", "ProductId" },
                values: new object[,]
                {
                    { 1, "png", "black_ecjeap", null },
                    { 2, "png", "red_e8saf2", null },
                    { 3, "png", "white_s8f0yl", null }
                });

            migrationBuilder.InsertData(
                table: "Size",
                columns: new[] { "SizeId", "Name" },
                values: new object[,]
                {
                    { 1, "XL" },
                    { 2, "XXL" },
                    { 3, "L" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "IsDeleted", "IsParent", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "T-Shirts", false, true, "T-Shirts", 1 },
                    { 3, "Casual Shirts", false, true, "Casual Shirts", 1 },
                    { 4, "Formal Shirts", false, true, "Formal Shirts", 1 },
                    { 5, "Sweatshirts", false, true, "Sweatshirts", 1 },
                    { 6, "Sweaters", false, true, "Sweaters", 1 },
                    { 7, "Jackets", false, true, "Jackets", 1 },
                    { 8, "Blazers & Coats", false, true, "Blazers & Coats", 1 },
                    { 9, "Suits", false, true, "Suits", 1 },
                    { 10, "Rain Jackets", false, true, "Rain Jackets", 1 },
                    { 12, "Kurtas & Kurta Sets", false, true, "Kurtas & Kurta Sets", 11 },
                    { 13, "Sherwanis", false, true, "Sherwanis", 11 },
                    { 14, "Nehru Jackets", false, true, "Nehru Jackets", 11 },
                    { 15, "Dhotis", false, true, "Dhotis", 11 },
                    { 17, "Jeans", false, true, "Jeans", 16 },
                    { 18, "Casual Trousers", false, true, "Casual Trousers", 16 },
                    { 19, "Formal Trousers", false, true, "Formal Trousers", 16 },
                    { 20, "Shorts", false, true, "Shorts", 16 },
                    { 21, "Track Pants & Joggers", false, true, "Track Pants & Joggers", 16 },
                    { 23, "Briefs & Trunks", false, true, "Briefs & Trunks", 22 },
                    { 24, "Boxers", false, true, "Boxers", 22 },
                    { 25, "Vests", false, true, "Vests", 22 },
                    { 26, "Sleepwear & Loungewear", false, true, "Sleepwear & Loungewear", 22 },
                    { 27, "Thermals", false, true, "Thermals", 22 },
                    { 30, "Casual Shoes", false, true, "Casual Shoes", 29 },
                    { 31, "Sports Shoes", false, true, "Sports Shoes", 29 },
                    { 32, "Formal Shoes", false, true, "Formal Shoes", 29 },
                    { 33, "Sneakers", false, true, "Sneakers", 29 },
                    { 34, "Sandals & Floaters", false, true, "Sandals & Floaters", 29 },
                    { 35, "Flip Flops", false, true, "Flip Flops", 29 },
                    { 36, "Socks", false, true, "Socks", 29 },
                    { 41, "Sports Shoes", false, true, "Sports Shoes", 40 },
                    { 42, "Sports Sandals", false, true, "Sports Sandals", 40 },
                    { 43, "Active T-Shirts", false, true, "Active T-Shirts", 40 },
                    { 44, "Track Pants & Shorts", false, true, "Track Pants & Shorts", 40 },
                    { 45, "Tracksuits", false, true, "Tracksuits", 40 },
                    { 46, "Jackets & Sweatshirts", false, true, "Jackets & Sweatshirts", 40 },
                    { 47, "Sports Accessories", false, true, "Sports Accessories", 40 },
                    { 48, "Swimwear", false, true, "Swimwear", 40 },
                    { 50, "Smart Wearables", false, true, "Smart Wearables", 49 },
                    { 51, "Fitness Gadgets", false, true, "Fitness Gadgets", 49 },
                    { 52, "Headphones", false, true, "Headphones", 49 },
                    { 53, "Speakers", false, true, "Speakers", 49 }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "IsDeleted", "IsParent", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 55, "Wallets", false, true, "Wallets", 54 },
                    { 56, "Belts", false, true, "Belts", 54 },
                    { 57, "Perfumes & Body Mists", false, true, "Perfumes & Body Mists", 54 },
                    { 58, "Trimmers", false, true, "Trimmers", 54 },
                    { 59, "Deodorants", false, true, "Deodorants", 54 },
                    { 60, "Ties, Cufflinks & Pocket Squares", false, true, "Ties, Cufflinks & Pocket Squares", 54 },
                    { 61, "Accessory Gift Sets", false, true, "Accessory Gift Sets", 54 },
                    { 62, "Caps & Hats", false, true, "Caps & Hats", 54 },
                    { 63, "Mufflers, Scarves & Gloves", false, true, "Mufflers, Scarves & Gloves", 54 },
                    { 64, "Phone Cases", false, true, "Phone Cases", 54 },
                    { 65, "Rings & Wristwear", false, true, "Rings & Wristwear", 54 },
                    { 66, "Helmets", false, true, "Helmets", 54 }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "ColorId", "Name", "ThumbnailImageId" },
                values: new object[,]
                {
                    { 1, "Black", 1 },
                    { 2, "Red", 2 },
                    { 3, "White", 3 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(4431), "Kids grow up so fast. Your little one may still be an infant, but we're sure they're crying for something stylish, comfortable, and eco-friendly. Well, you can satisfy their \"demands\" with this practical, organic Unisex..", false, "Unisex Baby Long Sleeve Bodysuits Set", 35.0 },
                    { 2, 1, new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(4433), "Long Sleeve 3D Printed Black Cat Sweatshirt", false, "Long Sleeve 3D Printed Black Cat Sweatshirt", 55.0 }
                });

            migrationBuilder.InsertData(
                table: "ColorProduct",
                columns: new[] { "ColorsColorId", "ProductsProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "Extension", "ImageName", "ProductId" },
                values: new object[,]
                {
                    { 4, "jpg", "yzsjv9f3zxeam2qrmsa5", 1 },
                    { 5, "jpg", "qqxtq42ju9u3f7xvqx41", 1 },
                    { 6, "jpg", "iyfpc8zlmsh3hpwhem8r", 2 },
                    { 7, "jpg", "wojbmn440oja7afudapp", 2 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(4434), "Look like the super star that you are while rocking this unisex Dreamville Street Wear Sweatshirt! It was made just for you.", false, "Dreamville Street Wear Sweatshirt", 55.0 },
                    { 5, 2, new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(4436), "Get the perfect wooden watch for yourself or a loved one - including a unique engraving in the back! This classic piece will match any outfit. NOTE: This watch is only available in the United States. ", false, "Walnut Wooden Watch", 98.0 }
                });

            migrationBuilder.InsertData(
                table: "ProductSize",
                columns: new[] { "ProductsProductId", "SizesSizeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "RatingId", "Comment", "CreatedDate", "ProductId", "RatingVal", "UserRating" },
                values: new object[,]
                {
                    { 1, "Nice one, i love this product", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5061), 1, 4, "user1" },
                    { 2, "Very beautiful and affordable price", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5063), 1, 4, "user2" },
                    { 3, "The watch make me feel very elegant", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5064), 2, 3, "user1" },
                    { 4, "Very beautiful and affordable price", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5065), 2, 3, "user2" },
                    { 5, "The watch make me feel very elegant", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5066), 2, 5, "user1" },
                    { 6, "Very beautiful and affordable price", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5066), 2, 4, "user2" },
                    { 11, "The watch make me feel very elegant", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5070), 2, 5, "user1" },
                    { 12, "Very beautiful and affordable price", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5071), 1, 3, "user2" },
                    { 14, "Very beautiful and affordable price", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5072), 1, 5, "user2" }
                });

            migrationBuilder.InsertData(
                table: "ColorProduct",
                columns: new[] { "ColorsColorId", "ProductsProductId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 1, 5 },
                    { 2, 3 },
                    { 2, 5 },
                    { 3, 3 },
                    { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "Extension", "ImageName", "ProductId" },
                values: new object[,]
                {
                    { 8, "jpg", "vjcyk00mvrrhadxdvgev", 3 },
                    { 9, "jpg", "buomsanrphup1hkzgwkg", 3 },
                    { 12, "jpg", "anllsn2gzufgiv0s6hgo", 5 },
                    { 13, "jpg", "oivszjvq5ccl1xsbnous", 5 }
                });

            migrationBuilder.InsertData(
                table: "ProductSize",
                columns: new[] { "ProductsProductId", "SizesSizeId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "RatingId", "Comment", "CreatedDate", "ProductId", "RatingVal", "UserRating" },
                values: new object[,]
                {
                    { 7, "The watch make me feel very elegant", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5067), 3, 2, "user1" },
                    { 8, "Very beautiful and affordable price", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5068), 3, 3, "user2" },
                    { 9, "The watch make me feel very elegant", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5069), 5, 3, "user1" },
                    { 10, "Very beautiful and affordable price", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5069), 5, 4, "user2" },
                    { 13, "The watch make me feel very elegant", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5071), 5, 2, "user1" },
                    { 15, "The watch make me feel very elegant", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5073), 5, 4, "user1" },
                    { 16, "Very beautiful and affordable price", new DateTime(2022, 3, 21, 23, 27, 38, 455, DateTimeKind.Local).AddTicks(5074), 3, 3, "user2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentCategoryId",
                table: "Category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Color_ThumbnailImageId",
                table: "Color",
                column: "ThumbnailImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorProduct_ProductsProductId",
                table: "ColorProduct",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSize_SizesSizeId",
                table: "ProductSize",
                column: "SizesSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ProductId",
                table: "Rating",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UpdatedDate_ProductId",
                table: "UpdatedDate",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ColorProduct");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "UpdatedDate");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
