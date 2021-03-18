using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodPal.Auth.Migrations
{
    public partial class Testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "86fa296f-c0c5-4619-90cf-d24afa4e49ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "client",
                column: "ConcurrencyStamp",
                value: "15e52b67-ba4a-477a-b1dc-fdabe0919e7a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "delivery",
                column: "ConcurrencyStamp",
                value: "75ffe318-90aa-4260-a4c0-ec3c1dc4c1e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "38fda6c5-526d-4115-8730-024ee23a6654", "AQAAAAEAACcQAAAAEKlI6L6IQFs03AtuInK2gjCABxfu2nQHKrOj6rf7MDQ2E3JSLZNT1riBfkryf8bpIA==", "bcde63bc-330e-499e-9172-79312728f002" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "f7e2b649-ec5c-48eb-bd24-747c1f3eafc0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "client",
                column: "ConcurrencyStamp",
                value: "f30a8c80-b2ca-4b40-9817-9b96328ca273");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "delivery",
                column: "ConcurrencyStamp",
                value: "3d44da47-a7c3-4951-b085-511c7dad857a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "505a5e1e-5c3f-4c54-9ad9-a209605829f7", "AQAAAAEAACcQAAAAEPC8YG0BeVgnnnnMhmI+yKydS3+myt8s+fzgwk6AmPGHlsM3uRoC1+4rHYtZrv5AdQ==", "2807097e-ca68-4c00-ba20-c06b00833c92" });
        }
    }
}
