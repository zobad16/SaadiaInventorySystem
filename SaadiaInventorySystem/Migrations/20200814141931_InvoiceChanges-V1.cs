using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class InvoiceChangesV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Invoices_Customers_CustomerId",
            //    table: "Invoices");

            //migrationBuilder.DropTable(
            //    name: "InvoiceItems");

            //migrationBuilder.DropIndex(
            //    name: "IX_Invoices_CustomerId",
            //    table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Invoices",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.AddColumn<bool>(
            //    name: "Confirmation",
            //    table: "Invoices",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<double>(
            //    name: "OfferedDiscount",
            //    table: "Invoices",
            //    nullable: false,
            //    defaultValue: 0.0);

            //migrationBuilder.AddColumn<int>(
            //    name: "OrderId",
            //    table: "Invoices",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.AddColumn<string>(
            //    name: "OrderPurchaseNumber",
            //    table: "Invoices",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "QuotaionId",
            //    table: "Invoices",
            //    nullable: true);

            //migrationBuilder.AddColumn<double>(
            //    name: "VAT",
            //    table: "Invoices",
            //    nullable: false,
            //    defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(823), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(1268) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2161), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2173) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2191), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2192) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2194), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2195) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2197), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2198) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2206), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2207) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2209), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2210) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2211), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2212) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2214), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2215) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2217), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2218) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2221), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(2222) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(5420), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(5851) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(6289), new DateTime(2020, 8, 14, 17, 19, 31, 247, DateTimeKind.Local).AddTicks(6311) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 249, DateTimeKind.Local).AddTicks(473), new DateTime(2020, 8, 14, 17, 19, 31, 249, DateTimeKind.Local).AddTicks(1405) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 245, DateTimeKind.Local).AddTicks(592), new DateTime(2020, 8, 14, 17, 19, 31, 245, DateTimeKind.Local).AddTicks(4729) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 14, 17, 19, 31, 245, DateTimeKind.Local).AddTicks(5229), new DateTime(2020, 8, 14, 17, 19, 31, 245, DateTimeKind.Local).AddTicks(5247) });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Invoices_CustomerId",
            //    table: "Invoices",
            //    column: "CustomerId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Invoices_OrderId",
            //    table: "Invoices",
            //    column: "OrderId",
            //    unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Orders_OrderId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Confirmation",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "OfferedDiscount",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "OrderPurchaseNumber",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "QuotaionId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Invoices",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(424), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(836) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1735), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1746) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1762), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1763) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1765), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1768), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1769) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1776), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1777) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1779), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1779) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1781), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1784), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1785) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1788), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1789) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1790), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1791) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(4851), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(5285) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(5743), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(5769) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 140, DateTimeKind.Local).AddTicks(6254), new DateTime(2020, 7, 27, 13, 9, 30, 140, DateTimeKind.Local).AddTicks(6665) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 137, DateTimeKind.Local).AddTicks(322), new DateTime(2020, 7, 27, 13, 9, 30, 137, DateTimeKind.Local).AddTicks(3954) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 137, DateTimeKind.Local).AddTicks(4465), new DateTime(2020, 7, 27, 13, 9, 30, 137, DateTimeKind.Local).AddTicks(4484) });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InventoryId",
                table: "InvoiceItems",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
