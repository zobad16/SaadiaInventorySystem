using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class InvoiceNewAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Attn",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MS",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Invoices",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(7162), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9222), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9239) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9268), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9274), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9278), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9294), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9296) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9299), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9301) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9304), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9305) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9308), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9317), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9318) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9324), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 64, DateTimeKind.Local).AddTicks(8998), new DateTime(2020, 8, 28, 19, 27, 27, 64, DateTimeKind.Local).AddTicks(9924) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 61, DateTimeKind.Local).AddTicks(4100), new DateTime(2020, 8, 28, 19, 27, 27, 61, DateTimeKind.Local).AddTicks(4932) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 61, DateTimeKind.Local).AddTicks(5789), new DateTime(2020, 8, 28, 19, 27, 27, 61, DateTimeKind.Local).AddTicks(5857) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 63, DateTimeKind.Local).AddTicks(4351), new DateTime(2020, 8, 28, 19, 27, 27, 63, DateTimeKind.Local).AddTicks(5023) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 57, DateTimeKind.Local).AddTicks(4203), new DateTime(2020, 8, 28, 19, 27, 27, 58, DateTimeKind.Local).AddTicks(2176) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 58, DateTimeKind.Local).AddTicks(3073), new DateTime(2020, 8, 28, 19, 27, 27, 58, DateTimeKind.Local).AddTicks(3105) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Attn",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "MS",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Invoices");

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

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 19, 15, 19, 58, 922, DateTimeKind.Local).AddTicks(3193), new DateTime(2020, 8, 19, 15, 19, 58, 922, DateTimeKind.Local).AddTicks(3602) });

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
    }
}
