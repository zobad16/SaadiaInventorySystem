using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class invoiceDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuotaionId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "QuotationId",
                table: "Invoices",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(7405), new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(7818) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8713), new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8724) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8743), new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8744) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8747), new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8748) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8749), new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8750) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8758), new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8759) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8760), new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8761) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8763), new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8764) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8765), new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8766) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8769), new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8770) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8772), new DateTime(2020, 8, 19, 15, 19, 58, 919, DateTimeKind.Local).AddTicks(8773) });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Confirmation", "CustomerId", "DateCreated", "DateUpdated", "IsActive", "OfferedDiscount", "OrderId", "OrderPurchaseNumber", "QuotationId", "VAT" },
                values: new object[] { 1, true, 2, new DateTime(2020, 8, 19, 15, 19, 58, 922, DateTimeKind.Local).AddTicks(3193), new DateTime(2020, 8, 19, 15, 19, 58, 922, DateTimeKind.Local).AddTicks(3602), 1, 0.20000000000000001, 1, "1903447049", 1, 5.0 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 920, DateTimeKind.Local).AddTicks(2235), new DateTime(2020, 8, 19, 15, 19, 58, 920, DateTimeKind.Local).AddTicks(2675) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 920, DateTimeKind.Local).AddTicks(3120), new DateTime(2020, 8, 19, 15, 19, 58, 920, DateTimeKind.Local).AddTicks(3143) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 921, DateTimeKind.Local).AddTicks(4168), new DateTime(2020, 8, 19, 15, 19, 58, 921, DateTimeKind.Local).AddTicks(4582) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 917, DateTimeKind.Local).AddTicks(7272), new DateTime(2020, 8, 19, 15, 19, 58, 918, DateTimeKind.Local).AddTicks(1491) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 918, DateTimeKind.Local).AddTicks(2005), new DateTime(2020, 8, 19, 15, 19, 58, 918, DateTimeKind.Local).AddTicks(2023) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "QuotationId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "QuotaionId",
                table: "Invoices",
                type: "int",
                nullable: true);

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
        }
    }
}
