using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class QuotationTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuotationItems");

            migrationBuilder.AddColumn<string>(
                name: "Attn",
                table: "Quotations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MS",
                table: "Quotations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Quotations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Quotations",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OfferedDiscount",
                table: "Quotations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Quotations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "QuotationNumber",
                table: "Quotations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceNumber",
                table: "Quotations",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VAT",
                table: "Quotations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    InventoryId = table.Column<int>(nullable: false),
                    OrderQty = table.Column<int>(nullable: false),
                    OfferedPrice = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => new { x.OrderId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_OrderItem_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 428, DateTimeKind.Local).AddTicks(8884), new DateTime(2020, 7, 1, 17, 28, 53, 428, DateTimeKind.Local).AddTicks(9294) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(179), new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(194) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(210), new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(211) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(213), new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(214) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(216), new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(217) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(224), new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(225) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(227), new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(228) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(230), new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(231) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(232), new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(233) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(236), new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(237) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(239), new DateTime(2020, 7, 1, 17, 28, 53, 429, DateTimeKind.Local).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 426, DateTimeKind.Local).AddTicks(9005), new DateTime(2020, 7, 1, 17, 28, 53, 427, DateTimeKind.Local).AddTicks(2711) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 17, 28, 53, 427, DateTimeKind.Local).AddTicks(3208), new DateTime(2020, 7, 1, 17, 28, 53, 427, DateTimeKind.Local).AddTicks(3225) });

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_OrderId",
                table: "Quotations",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_InventoryId",
                table: "OrderItem",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Orders_OrderId",
                table: "Quotations",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Orders_OrderId",
                table: "Quotations");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_OrderId",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Attn",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "MS",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "OfferedDiscount",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "QuotationNumber",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "ReferenceNumber",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "Quotations");

            migrationBuilder.CreateTable(
                name: "QuotationItems",
                columns: table => new
                {
                    QuotationId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(3769), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(4235) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5459), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5475) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5493), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5495) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5497), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5498) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5500), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5501) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5510), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5511) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5513), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5513) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5515), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5516) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5518), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5524), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5525) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5528), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5529) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 551, DateTimeKind.Local).AddTicks(6342), new DateTime(2020, 6, 17, 19, 5, 13, 552, DateTimeKind.Local).AddTicks(6555) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 552, DateTimeKind.Local).AddTicks(7131), new DateTime(2020, 6, 17, 19, 5, 13, 552, DateTimeKind.Local).AddTicks(7154) });

            migrationBuilder.CreateIndex(
                name: "IX_QuotationItems_InventoryId",
                table: "QuotationItems",
                column: "InventoryId");
        }
    }
}
