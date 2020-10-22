using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class InvoiceConfirmation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inquirys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateIssued", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 50, DateTimeKind.Local).AddTicks(9799), new DateTime(2020, 10, 21, 9, 27, 3, 50, DateTimeKind.Local).AddTicks(9385), new DateTime(2020, 10, 21, 9, 27, 3, 51, DateTimeKind.Local).AddTicks(190) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(7220), new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(7674) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9008), new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9020) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9037), new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9039) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9041), new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9042) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9044), new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9045) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9056), new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9057) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9061), new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9062) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9067), new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9069) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9072), new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9073) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9076), new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9077) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9084), new DateTime(2020, 10, 21, 9, 27, 3, 47, DateTimeKind.Local).AddTicks(9085) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 50, DateTimeKind.Local).AddTicks(4005), new DateTime(2020, 10, 21, 9, 27, 3, 50, DateTimeKind.Local).AddTicks(4407) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 48, DateTimeKind.Local).AddTicks(3520), new DateTime(2020, 10, 21, 9, 27, 3, 48, DateTimeKind.Local).AddTicks(4319) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 48, DateTimeKind.Local).AddTicks(4771), new DateTime(2020, 10, 21, 9, 27, 3, 48, DateTimeKind.Local).AddTicks(4804) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 49, DateTimeKind.Local).AddTicks(5554), new DateTime(2020, 10, 21, 9, 27, 3, 49, DateTimeKind.Local).AddTicks(5965) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 45, DateTimeKind.Local).AddTicks(2400), new DateTime(2020, 10, 21, 9, 27, 3, 46, DateTimeKind.Local).AddTicks(1063) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 9, 27, 3, 46, DateTimeKind.Local).AddTicks(1574), new DateTime(2020, 10, 21, 9, 27, 3, 46, DateTimeKind.Local).AddTicks(1612) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inquirys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateIssued", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 808, DateTimeKind.Local).AddTicks(6701), new DateTime(2020, 10, 21, 8, 48, 49, 808, DateTimeKind.Local).AddTicks(6132), new DateTime(2020, 10, 21, 8, 48, 49, 808, DateTimeKind.Local).AddTicks(7181) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(362), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(879) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2110), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2142), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2144) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2146), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2147) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2149), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2150) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2157), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2158) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2160), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2161) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2163), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2164) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2166), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2167) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2170), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2171) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2173), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(2174) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 807, DateTimeKind.Local).AddTicks(9732), new DateTime(2020, 10, 21, 8, 48, 49, 808, DateTimeKind.Local).AddTicks(184) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(5862), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(6339) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(6977), new DateTime(2020, 10, 21, 8, 48, 49, 805, DateTimeKind.Local).AddTicks(7008) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 806, DateTimeKind.Local).AddTicks(9070), new DateTime(2020, 10, 21, 8, 48, 49, 806, DateTimeKind.Local).AddTicks(9622) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 802, DateTimeKind.Local).AddTicks(23), new DateTime(2020, 10, 21, 8, 48, 49, 803, DateTimeKind.Local).AddTicks(992) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 21, 8, 48, 49, 803, DateTimeKind.Local).AddTicks(1677), new DateTime(2020, 10, 21, 8, 48, 49, 803, DateTimeKind.Local).AddTicks(1697) });
        }
    }
}
