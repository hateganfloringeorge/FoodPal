using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodPal.Auth.Migrations
{
    public partial class AddExtraUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "e87e540b-874c-42b7-bfda-72fe244da1d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "client",
                column: "ConcurrencyStamp",
                value: "9a1aa6c1-8c2d-4fc8-a1c9-ca814ecdc281");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "delivery",
                column: "ConcurrencyStamp",
                value: "0a46366a-976c-4873-9f00-f1f01ce88c0e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77d3fb66-cdd0-49b1-bb9b-67313034b3ce", "AQAAAAEAACcQAAAAEC0yAHAlvoZSPW6OIupII76XQtrkFwbX8n5i7IECdwv7Gtqw/JUv89JJRXOLXhPsuw==", "b0cff6ab-4550-4e1e-b678-b8ac4f378c6e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "79bb3d31-b51b-4ca3-b550-b2c3b7e26a99");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "client",
                column: "ConcurrencyStamp",
                value: "fcfd0271-d4f4-46c5-8ca1-6785f397d3b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "delivery",
                column: "ConcurrencyStamp",
                value: "69da220c-5865-44ce-a8c0-e768eea4a2d7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2896dcd1-32a1-4c95-b372-bc560a03ddf9", "AQAAAAEAACcQAAAAEAhqAlhzTQkLDPi/aEKBKFB01An31WSxU0VUhmh/XGPIMOjx1OM0AtyfM6W7VKkB6g==", "686d7732-3734-4752-bc80-d1112f37d4f4" });
        }
    }
}
