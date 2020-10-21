using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class InvoiceQuotationNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "QuotationNumber",
                table: "Invoices",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuotationNumber",
                table: "Invoices");

            migrationBuilder.UpdateData(
                table: "Inquirys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateIssued", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 55, DateTimeKind.Local).AddTicks(5664), new DateTime(2020, 10, 15, 12, 53, 20, 55, DateTimeKind.Local).AddTicks(5170), new DateTime(2020, 10, 15, 12, 53, 20, 55, DateTimeKind.Local).AddTicks(6271) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 51, DateTimeKind.Local).AddTicks(9997), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(486) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1598), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1609) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1626), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1628) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1630), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1631) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1634), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1643), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1644) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1646), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1648) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1649), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1651) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1652), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1725), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1726) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1730), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1731) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 54, DateTimeKind.Local).AddTicks(8733), new DateTime(2020, 10, 15, 12, 53, 20, 54, DateTimeKind.Local).AddTicks(9212) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(5282), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(5801) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(6330), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(6357) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 53, DateTimeKind.Local).AddTicks(8542), new DateTime(2020, 10, 15, 12, 53, 20, 53, DateTimeKind.Local).AddTicks(9036) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 49, DateTimeKind.Local).AddTicks(2319), new DateTime(2020, 10, 15, 12, 53, 20, 50, DateTimeKind.Local).AddTicks(1888) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 50, DateTimeKind.Local).AddTicks(2507), new DateTime(2020, 10, 15, 12, 53, 20, 50, DateTimeKind.Local).AddTicks(2548) });
        }
    }
}
