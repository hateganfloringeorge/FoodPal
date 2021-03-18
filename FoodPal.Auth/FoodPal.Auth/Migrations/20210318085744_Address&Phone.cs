using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodPal.Auth.Migrations
{
    public partial class AddressPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "84e4ac44-0756-4026-8226-954de2401fe4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "client",
                column: "ConcurrencyStamp",
                value: "12d57950-621c-44bf-a7c0-091f0e03a6b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "delivery",
                column: "ConcurrencyStamp",
                value: "0b25a190-f860-4a0c-8030-07c16c155625");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ADMIN",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab7f8ba8-f37a-4115-a284-fcf3fcec2ec6", "AQAAAAEAACcQAAAAEHDy5PA+gK5kD7fi38Pn5AI4Dh36Lwa/e42PqPqglFJCR3xhoddYkSGscGrjkZt/Qw==", "5bf19072-adc8-4140-a65a-8822a8fbfffe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

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
    }
}
