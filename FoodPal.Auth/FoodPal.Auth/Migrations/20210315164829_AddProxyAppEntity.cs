using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodPal.Auth.Migrations
{
    public partial class AddProxyAppEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProxyApps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProxyApps", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProxyApps");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "b096e812-e72f-4700-a6ff-217e5c8afa68");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "client",
                column: "ConcurrencyStamp",
                value: "97d458fe-ff77-49c4-bf12-a54caa9ee2d5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "delivery",
                column: "ConcurrencyStamp",
                value: "f92e38c7-df0f-4250-ab9b-307c62f77186");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4acad805-2387-4875-84f7-00e1dfe6300c", "AQAAAAEAACcQAAAAEA1C9Zfg76M1a3IqRMZwWAbJ0iDeeQB8hhnakgtvdMUiLghEhh3Tradgo3Kufd/WXg==", "cf5b9d0c-dde6-4fd6-b39a-9349c1d0cb60" });
        }
    }
}
