using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class QuotationSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(6057), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(6503) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7500), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7529), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7530) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7532), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7532) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7534), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7535) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7544), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7544) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7546), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7547) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7549), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7550) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7552), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7553) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7556), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7557) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7559), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7560) });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DateCreated", "DateUpdated" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 7, 1, 19, 7, 3, 69, DateTimeKind.Local).AddTicks(1027), new DateTime(2020, 7, 1, 19, 7, 3, 69, DateTimeKind.Local).AddTicks(1499) },
                    { 2, new DateTime(2020, 7, 1, 19, 7, 3, 69, DateTimeKind.Local).AddTicks(1974), new DateTime(2020, 7, 1, 19, 7, 3, 69, DateTimeKind.Local).AddTicks(2000) }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 66, DateTimeKind.Local).AddTicks(5888), new DateTime(2020, 7, 1, 19, 7, 3, 66, DateTimeKind.Local).AddTicks(9852) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 67, DateTimeKind.Local).AddTicks(348), new DateTime(2020, 7, 1, 19, 7, 3, 67, DateTimeKind.Local).AddTicks(365) });

            migrationBuilder.InsertData(
                table: "OrderItem",
                columns: new[] { "OrderId", "InventoryId", "OfferedPrice", "OrderQty", "Total" },
                values: new object[,]
                {
                    { 1, 10, 200.0, 2, 400.0 },
                    { 1, 3, 200.0, 2, 400.0 },
                    { 2, 3, 200.0, 2, 400.0 },
                    { 2, 10, 200.0, 2, 400.0 }
                });

            migrationBuilder.InsertData(
                table: "Quotations",
                columns: new[] { "Id", "Attn", "CustomerId", "DateCreated", "DateUpdated", "IsActive", "MS", "Message", "Note", "OfferedDiscount", "OrderId", "QuotationNumber", "ReferenceNumber", "VAT" },
                values: new object[] { 1, "Negotiation", 2, new DateTime(2020, 7, 1, 19, 7, 3, 70, DateTimeKind.Local).AddTicks(2950), new DateTime(2020, 7, 1, 19, 7, 3, 70, DateTimeKind.Local).AddTicks(3405), 1, "SAADIA TRADING CO.LLC", @"Delivery: 5 days on order confirmation., Price quoted Net in UAE Dirhams, ex-warehouse.
Make: Genuine Part
Validity: 1 week 
Payment: 100% cash on order confirmation.
Awaiting your valued order & assuring you of our best services always.", "Dear Sir.Thank you for your inquiry. We are pleased to quote our best prices as follows:", 0.0, 1, null, "NISSAN.TFA430K00725", 5.0 });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem");

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumns: new[] { "OrderId", "InventoryId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumns: new[] { "OrderId", "InventoryId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumns: new[] { "OrderId", "InventoryId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "OrderItem",
                keyColumns: new[] { "OrderId", "InventoryId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
