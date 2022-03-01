using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookiesFashion.APIService.Data.Migrations
{
    public partial class Init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorProduct_Color_ColorsColorId",
                table: "ColorProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ColorProduct_Product_ProductsProductId",
                table: "ColorProduct");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 1, 13, 50, 18, 944, DateTimeKind.Local).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 1, 13, 50, 18, 944, DateTimeKind.Local).AddTicks(3892));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 1, 13, 50, 18, 944, DateTimeKind.Local).AddTicks(3893));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 1, 13, 50, 18, 944, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.AddForeignKey(
                name: "FK_ColorProduct_Color_ColorsColorId",
                table: "ColorProduct",
                column: "ColorsColorId",
                principalTable: "Color",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColorProduct_Product_ProductsProductId",
                table: "ColorProduct",
                column: "ProductsProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorProduct_Color_ColorsColorId",
                table: "ColorProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_ColorProduct_Product_ProductsProductId",
                table: "ColorProduct");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 25, 10, 4, 14, 622, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 25, 10, 4, 14, 622, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 25, 10, 4, 14, 622, DateTimeKind.Local).AddTicks(1705));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 25, 10, 4, 14, 622, DateTimeKind.Local).AddTicks(1706));

            migrationBuilder.AddForeignKey(
                name: "FK_ColorProduct_Color_ColorsColorId",
                table: "ColorProduct",
                column: "ColorsColorId",
                principalTable: "Color",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ColorProduct_Product_ProductsProductId",
                table: "ColorProduct",
                column: "ProductsProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
