using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookiesFashion.APIService.Data.Migrations
{
    public partial class addsoftdelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Product",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(6719));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7394));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7396));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7397));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7397));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7398));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7399));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7401));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7403));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7404));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 4, 51, 48, 394, DateTimeKind.Local).AddTicks(7405));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Product");

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
    }
}
