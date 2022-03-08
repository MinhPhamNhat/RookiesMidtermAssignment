using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookiesFashion.APIService.Data.Migrations
{
    public partial class RatingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Product_ProductId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_User_UserRatingUserId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "RatingProductId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "RatingUserId",
                table: "Rating");

            migrationBuilder.AlterColumn<int>(
                name: "UserRatingUserId",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Rating",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "RatingId", "Comment", "CreatedDate", "ProductId", "RatingVal", "UserRatingUserId" },
                values: new object[,]
                {
                    { 1, "Nice one, i love this product", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6738), 1, 4, 1 },
                    { 2, "Very beautiful and affordable price", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6741), 1, 4, 2 },
                    { 3, "The watch make me feel very elegant", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6742), 2, 3, 1 },
                    { 4, "Very beautiful and affordable price", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6743), 2, 3, 2 },
                    { 5, "The watch make me feel very elegant", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6743), 2, 5, 1 },
                    { 6, "Very beautiful and affordable price", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6744), 2, 4, 2 },
                    { 7, "The watch make me feel very elegant", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6745), 3, 2, 1 },
                    { 8, "Very beautiful and affordable price", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6745), 3, 3, 2 },
                    { 9, "The watch make me feel very elegant", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6746), 5, 3, 1 },
                    { 10, "Very beautiful and affordable price", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6747), 5, 4, 2 },
                    { 11, "The watch make me feel very elegant", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6747), 2, 5, 1 },
                    { 12, "Very beautiful and affordable price", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6748), 1, 3, 2 },
                    { 13, "The watch make me feel very elegant", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6749), 5, 2, 1 },
                    { 14, "Very beautiful and affordable price", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6750), 1, 5, 2 },
                    { 15, "The watch make me feel very elegant", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6751), 5, 4, 1 },
                    { 16, "Very beautiful and affordable price", new DateTime(2022, 3, 8, 11, 48, 5, 289, DateTimeKind.Local).AddTicks(6751), 3, 3, 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Product_ProductId",
                table: "Rating",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_User_UserRatingUserId",
                table: "Rating",
                column: "UserRatingUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Product_ProductId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_User_UserRatingUserId",
                table: "Rating");

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "RatingId",
                keyValue: 16);

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Rating");

            migrationBuilder.AlterColumn<int>(
                name: "UserRatingUserId",
                table: "Rating",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Rating",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RatingProductId",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RatingUserId",
                table: "Rating",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Product_ProductId",
                table: "Rating",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_User_UserRatingUserId",
                table: "Rating",
                column: "UserRatingUserId",
                principalTable: "User",
                principalColumn: "UserId");
        }
    }
}
