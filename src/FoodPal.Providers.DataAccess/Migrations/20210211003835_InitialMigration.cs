using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodPal.Providers.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogueItemCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogueItemCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProviderCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Providers_ProviderCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProviderCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalogue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catalogue_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatalogueItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    CatalogueId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogueItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogueItems_Catalogue_CatalogueId",
                        column: x => x.CatalogueId,
                        principalTable: "Catalogue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogueItems_CatalogueItemCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CatalogueItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CatalogueItemCategory",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 11, 2, 38, 34, 513, DateTimeKind.Local).AddTicks(8245), "Dessert" },
                    { 2, new DateTime(2021, 2, 11, 2, 38, 34, 513, DateTimeKind.Local).AddTicks(8917), "Main Course" },
                    { 3, new DateTime(2021, 2, 11, 2, 38, 34, 513, DateTimeKind.Local).AddTicks(8929), "Soups" },
                    { 4, new DateTime(2021, 2, 11, 2, 38, 34, 513, DateTimeKind.Local).AddTicks(8932), "Apperitives" }
                });

            migrationBuilder.InsertData(
                table: "ProviderCategory",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 11, 2, 38, 34, 508, DateTimeKind.Local).AddTicks(3726), "Mediteranean Cousine" },
                    { 2, new DateTime(2021, 2, 11, 2, 38, 34, 512, DateTimeKind.Local).AddTicks(337), "Tradinional Romanian Cousine" },
                    { 3, new DateTime(2021, 2, 11, 2, 38, 34, 512, DateTimeKind.Local).AddTicks(405), "Japonese Cousine" },
                    { 4, new DateTime(2021, 2, 11, 2, 38, 34, 512, DateTimeKind.Local).AddTicks(410), "Thai Cousine" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogue_ProviderId",
                table: "Catalogue",
                column: "ProviderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CatalogueItems_CatalogueId",
                table: "CatalogueItems",
                column: "CatalogueId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogueItems_CategoryId",
                table: "CatalogueItems",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_CategoryId",
                table: "Providers",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogueItems");

            migrationBuilder.DropTable(
                name: "Catalogue");

            migrationBuilder.DropTable(
                name: "CatalogueItemCategory");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "ProviderCategory");
        }
    }
}
