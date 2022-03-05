using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookiesFashion.APIService.Data.Migrations
{
    public partial class ProductAverageRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 15, 49, 33, 860, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 15, 49, 33, 860, DateTimeKind.Local).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 15, 49, 33, 860, DateTimeKind.Local).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 15, 49, 33, 860, DateTimeKind.Local).AddTicks(464));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
