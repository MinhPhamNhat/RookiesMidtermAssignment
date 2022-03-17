using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookiesFashion.APIService.Data.Migrations
{
    public partial class addaveragecomputing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2982));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2985));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2987));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2989));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2990));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2990));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2994));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2995));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2996));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 16, 17, 41, 25, 540, DateTimeKind.Local).AddTicks(2998));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6202));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6204));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6738));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6742));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6743));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6743));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6745));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6745));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6749));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6751));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6751));
        }
    }
}
