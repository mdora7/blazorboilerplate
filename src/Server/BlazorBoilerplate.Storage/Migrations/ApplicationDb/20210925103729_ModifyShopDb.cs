using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorBoilerplate.Storage.Migrations.ApplicationDb
{
    public partial class ModifyShopDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductEditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductEditions_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductEditions_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visits = table.Column<int>(type: "int", nullable: false),
                    LastVisit = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStats_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductStats_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EditionId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => new { x.ProductId, x.EditionId });
                    table.ForeignKey(
                        name: "FK_ProductVariants_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariants_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariants_ProductEditions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "ProductEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductEditions_CreatedById",
                table: "ProductEditions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEditions_ModifiedById",
                table: "ProductEditions",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStats_CreatedById",
                table: "ProductStats",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStats_ModifiedById",
                table: "ProductStats",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_CreatedById",
                table: "ProductVariants",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_EditionId",
                table: "ProductVariants",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ModifiedById",
                table: "ProductVariants",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId1",
                table: "ProductVariants",
                column: "ProductId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStats");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "ProductEditions");
        }
    }
}
