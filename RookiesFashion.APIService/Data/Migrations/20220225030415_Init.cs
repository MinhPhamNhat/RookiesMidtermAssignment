using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookiesFashion.APIService.Data.Migrations
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
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
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
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
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
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IdentityUsername = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Account_IdentityUsername",
                        column: x => x.IdentityUsername,
                        principalTable: "Account",
                        principalColumn: "Username");
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatingVal = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingProductId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    RatingUserId = table.Column<int>(type: "int", nullable: false),
                    UserRatingUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Rating_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Rating_User_UserRatingUserId",
                        column: x => x.UserRatingUserId,
                        principalTable: "User",
                        principalColumn: "UserId");
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColorProduct_Product_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Username", "Password" },
                values: new object[,]
                {
                    { "ADMIN", "ADMIN" },
                    { "User1", "rookies_user1" },
                    { "User2", "rookies_user2" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "IsParent", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Topwear", true, "Topwear", null },
                    { 11, "Indian & Festive Wear", true, "Indian & Festive Wear", null },
                    { 16, "Bottomwear", true, "Bottomwear", null },
                    { 22, "Innerwear & Sleepwear", true, "Innerwear & Sleepwear", null },
                    { 28, "Plus Size", true, "Plus Size", null },
                    { 29, "Footwear", true, "Footwear", null },
                    { 37, "Personal Care & Grooming", true, "Personal Care & Grooming", null },
                    { 38, "Sunglasses & Frames", true, "Sunglasses & Frames", null },
                    { 39, "Watches", true, "Watches", null },
                    { 40, "Sports & Active Wear", true, "Sports & Active Wear", null },
                    { 49, "Gadgets", true, "Gadgets", null },
                    { 54, "Fashion Accessories", true, "Fashion Accessories", null }
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
                table: "Role",
                columns: new[] { "RoleId", "Description" },
                values: new object[,]
                {
                    { 0, "Administrator" },
                    { 1, "User" }
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
                columns: new[] { "CategoryId", "Description", "IsParent", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "T-Shirts", false, "T-Shirts", 1 },
                    { 3, "Casual Shirts", false, "Casual Shirts", 1 },
                    { 4, "Formal Shirts", false, "Formal Shirts", 1 },
                    { 5, "Sweatshirts", false, "Sweatshirts", 1 },
                    { 6, "Sweaters", false, "Sweaters", 1 },
                    { 7, "Jackets", false, "Jackets", 1 },
                    { 8, "Blazers & Coats", false, "Blazers & Coats", 1 },
                    { 9, "Suits", false, "Suits", 1 },
                    { 10, "Rain Jackets", false, "Rain Jackets", 1 },
                    { 12, "Kurtas & Kurta Sets", false, "Kurtas & Kurta Sets", 11 },
                    { 13, "Sherwanis", false, "Sherwanis", 11 },
                    { 14, "Nehru Jackets", false, "Nehru Jackets", 11 },
                    { 15, "Dhotis", false, "Dhotis", 11 },
                    { 17, "Jeans", false, "Jeans", 16 },
                    { 18, "Casual Trousers", false, "Casual Trousers", 16 },
                    { 19, "Formal Trousers", false, "Formal Trousers", 16 },
                    { 20, "Shorts", false, "Shorts", 16 },
                    { 21, "Track Pants & Joggers", false, "Track Pants & Joggers", 16 },
                    { 23, "Briefs & Trunks", false, "Briefs & Trunks", 22 },
                    { 24, "Boxers", false, "Boxers", 22 },
                    { 25, "Vests", false, "Vests", 22 },
                    { 26, "Sleepwear & Loungewear", false, "Sleepwear & Loungewear", 22 },
                    { 27, "Thermals", false, "Thermals", 22 },
                    { 30, "Casual Shoes", false, "Casual Shoes", 29 },
                    { 31, "Sports Shoes", false, "Sports Shoes", 29 },
                    { 32, "Formal Shoes", false, "Formal Shoes", 29 },
                    { 33, "Sneakers", false, "Sneakers", 29 },
                    { 34, "Sandals & Floaters", false, "Sandals & Floaters", 29 },
                    { 35, "Flip Flops", false, "Flip Flops", 29 },
                    { 36, "Socks", false, "Socks", 29 },
                    { 41, "Sports Shoes", false, "Sports Shoes", 40 },
                    { 42, "Sports Sandals", false, "Sports Sandals", 40 },
                    { 43, "Active T-Shirts", false, "Active T-Shirts", 40 },
                    { 44, "Track Pants & Shorts", false, "Track Pants & Shorts", 40 },
                    { 45, "Tracksuits", false, "Tracksuits", 40 },
                    { 46, "Jackets & Sweatshirts", false, "Jackets & Sweatshirts", 40 },
                    { 47, "Sports Accessories", false, "Sports Accessories", 40 },
                    { 48, "Swimwear", false, "Swimwear", 40 },
                    { 50, "Smart Wearables", false, "Smart Wearables", 49 },
                    { 51, "Fitness Gadgets", false, "Fitness Gadgets", 49 },
                    { 52, "Headphones", false, "Headphones", 49 },
                    { 53, "Speakers", false, "Speakers", 49 }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "IsParent", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 55, "Wallets", false, "Wallets", 54 },
                    { 56, "Belts", false, "Belts", 54 },
                    { 57, "Perfumes & Body Mists", false, "Perfumes & Body Mists", 54 },
                    { 58, "Trimmers", false, "Trimmers", 54 },
                    { 59, "Deodorants", false, "Deodorants", 54 },
                    { 60, "Ties, Cufflinks & Pocket Squares", false, "Ties, Cufflinks & Pocket Squares", 54 },
                    { 61, "Accessory Gift Sets", false, "Accessory Gift Sets", 54 },
                    { 62, "Caps & Hats", false, "Caps & Hats", 54 },
                    { 63, "Mufflers, Scarves & Gloves", false, "Mufflers, Scarves & Gloves", 54 },
                    { 64, "Phone Cases", false, "Phone Cases", 54 },
                    { 65, "Rings & Wristwear", false, "Rings & Wristwear", 54 },
                    { 66, "Helmets", false, "Helmets", 54 }
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
                columns: new[] { "ProductId", "CategoryId", "CreatedDate", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 2, 25, 10, 4, 14, 622, DateTimeKind.Local).AddTicks(1700), "Kids grow up so fast. Your little one may still be an infant, but we're sure they're crying for something stylish, comfortable, and eco-friendly. Well, you can satisfy their \"demands\" with this practical, organic Unisex..", "Unisex Baby Long Sleeve Bodysuits Set", 35.0 },
                    { 2, 1, new DateTime(2022, 2, 25, 10, 4, 14, 622, DateTimeKind.Local).AddTicks(1703), "Long Sleeve 3D Printed Black Cat Sweatshirt", "Long Sleeve 3D Printed Black Cat Sweatshirt", 55.0 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "IdentityUsername", "Name", "RoleId" },
                values: new object[,]
                {
                    { 1, "ADMIN", "ADMIN", 0 },
                    { 2, "User1", "Rookies User 1", 1 },
                    { 3, "User2", "Rookies User 2", 1 }
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
                columns: new[] { "ProductId", "CategoryId", "CreatedDate", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 3, 3, new DateTime(2022, 2, 25, 10, 4, 14, 622, DateTimeKind.Local).AddTicks(1705), "Look like the super star that you are while rocking this unisex Dreamville Street Wear Sweatshirt! It was made just for you.", "Dreamville Street Wear Sweatshirt", 55.0 },
                    { 5, 2, new DateTime(2022, 2, 25, 10, 4, 14, 622, DateTimeKind.Local).AddTicks(1706), "Get the perfect wooden watch for yourself or a loved one - including a unique engraving in the back! This classic piece will match any outfit. NOTE: This watch is only available in the United States. ", "Walnut Wooden Watch", 98.0 }
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
                name: "IX_Rating_UserRatingUserId",
                table: "Rating",
                column: "UserRatingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UpdatedDate_ProductId",
                table: "UpdatedDate",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdentityUsername",
                table: "User",
                column: "IdentityUsername");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorProduct");

            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "UpdatedDate");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
