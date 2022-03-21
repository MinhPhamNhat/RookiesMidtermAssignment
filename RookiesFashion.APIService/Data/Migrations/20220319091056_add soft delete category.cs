using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookiesFashion.APIService.Data.Migrations
{
    public partial class addsoftdeletecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(6505));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(6507));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7138));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7140));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7141));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7202));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7203));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7207));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7208));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7209));

            migrationBuilder.UpdateData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 19, 16, 10, 55, 569, DateTimeKind.Local).AddTicks(7210));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Category");

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
    }
}
