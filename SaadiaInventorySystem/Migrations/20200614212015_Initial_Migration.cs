using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    ComapnyName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Trn = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OldParts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Rem = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OldParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PartNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    AvailableQty = table.Column<int>(nullable: false),
                    Rem = table.Column<string>(nullable: true),
                    OldPartFK = table.Column<int>(nullable: true),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_OldParts_OldPartFK",
                        column: x => x.OldPartFK,
                        principalTable: "OldParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    IsActive = table.Column<int>(nullable: false),
                    RoleFk = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleFk",
                        column: x => x.RoleFk,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false),
                    InventoryId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => new { x.InvoiceId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuotationItems",
                columns: table => new
                {
                    QuotationId = table.Column<int>(nullable: false),
                    InventoryId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuotationItems", x => new { x.QuotationId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_QuotationItems_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuotationItems_Quotations_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "Quotations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "ComapnyName", "DateCreated", "DateUpdated", "EmailAddress", "FirstName", "LastName", "PhoneNumber", "Postcode", "Trn" },
                values: new object[,]
                {
                    { 1, null, "QTS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "zobad.mahmood@gmail.com", "Zobad", "Mahmood", null, null, null },
                    { 2, null, "Saadia", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hamza@gmail.com", "Hamza", "Sheikh", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "AvailableQty", "DateCreated", "DateUpdate", "Description", "IsActive", "Location", "OldPartFK", "PartNumber", "Rem", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2020, 6, 15, 0, 20, 15, 268, DateTimeKind.Local).AddTicks(504), new DateTime(2020, 6, 15, 0, 20, 15, 268, DateTimeKind.Local).AddTicks(920), "OIL FILTER", 1, "1A1", null, "15613-EV015", "GN", 0.0m },
                    { 2, 3, new DateTime(2020, 6, 15, 0, 20, 15, 268, DateTimeKind.Local).AddTicks(1817), new DateTime(2020, 6, 15, 0, 20, 15, 268, DateTimeKind.Local).AddTicks(1828), "FUEL FILTER", 1, "1A1", null, "23304-EV052", "GN", 0.0m },
                    { 3, 2, new DateTime(2020, 6, 15, 0, 20, 15, 268, DateTimeKind.Local).AddTicks(1845), new DateTime(2020, 6, 15, 0, 20, 15, 268, DateTimeKind.Local).AddTicks(1847), "FUEL FILTER", 1, "1A1", null, "23304-78091", "GN", 0.0m }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdate", "EmailAddress", "FirstName", "IsActive", "LastName", "Password", "PhoneNumber", "RoleFk", "UserName" },
                values: new object[] { 1, new DateTime(2020, 6, 15, 0, 20, 15, 266, DateTimeKind.Local).AddTicks(447), new DateTime(2020, 6, 15, 0, 20, 15, 267, DateTimeKind.Local).AddTicks(291), null, "Zobad", 1, "Mahmood", "1234", null, 1, "zobad" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "DateUpdate", "EmailAddress", "FirstName", "IsActive", "LastName", "Password", "PhoneNumber", "RoleFk", "UserName" },
                values: new object[] { 2, new DateTime(2020, 6, 15, 0, 20, 15, 267, DateTimeKind.Local).AddTicks(876), new DateTime(2020, 6, 15, 0, 20, 15, 267, DateTimeKind.Local).AddTicks(896), null, "Hamza", 1, "Sheikh", "1234", null, 2, "hamza" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_OldPartFK",
                table: "Inventories",
                column: "OldPartFK",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InventoryId",
                table: "InvoiceItems",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuotationItems_InventoryId",
                table: "QuotationItems",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CustomerId",
                table: "Quotations",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleFk",
                table: "Users",
                column: "RoleFk",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "QuotationItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "OldParts");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
