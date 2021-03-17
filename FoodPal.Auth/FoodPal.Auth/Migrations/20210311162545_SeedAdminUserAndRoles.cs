using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodPal.Auth.Migrations
{
    public partial class SeedAdminUserAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "client", "fcfd0271-d4f4-46c5-8ca1-6785f397d3b2", "Client", "CLIENT" },
                    { "delivery", "69da220c-5865-44ce-a8c0-e768eea4a2d7", "Delivery Person", "DELIVERY_PERSON" },
                    { "admin", "79bb3d31-b51b-4ca3-b550-b2c3b7e26a99", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ADMIN", 0, "2896dcd1-32a1-4c95-b372-bc560a03ddf9", "cristian.hosu@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEAhqAlhzTQkLDPi/aEKBKFB01An31WSxU0VUhmh/XGPIMOjx1OM0AtyfM6W7VKkB6g==", null, false, "686d7732-3734-4752-bc80-d1112f37d4f4", false, "cristian.hosu@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "client");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "delivery");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin", "ADMIN" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN");
        }
    }
}
