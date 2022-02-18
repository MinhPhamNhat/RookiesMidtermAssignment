using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RookiesFashion.APIService.Data.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CategoryId", "Description", "Name", "ParentCategoryId" },
                values: new object[] { 1, "Áo", "Áo", null });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleId", "Description" },
                values: new object[,]
                {
                    { 0, "Administrator" },
                    { 1, "User" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Áo khoác", "Áo khoác", 1 },
                    { 3, "Áo Hoodie", "Áo Hoodie", 1 },
                    { 4, "Áo Thun", "Áo Hoodie", 1 }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Username",
                keyValue: "ADMIN");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Username",
                keyValue: "User1");

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Username",
                keyValue: "User2");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleId",
                keyValue: 1);
        }
    }
}
