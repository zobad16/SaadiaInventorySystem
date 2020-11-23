using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class Invoice_InvoiceNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InvoiceNumber",
                table: "Invoices",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Inquirys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateIssued", "DateUpdated" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 150, DateTimeKind.Local).AddTicks(7592), new DateTime(2020, 11, 22, 18, 3, 28, 150, DateTimeKind.Local).AddTicks(6955), new DateTime(2020, 11, 22, 18, 3, 28, 150, DateTimeKind.Local).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(4259), new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(4708) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5689), new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5700) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5718), new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5719) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5722), new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5723) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5725), new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5726) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5734), new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5735) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5737), new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5738) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5739), new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5740) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5742), new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5743) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5746), new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5747) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5749), new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(5750) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 150, DateTimeKind.Local).AddTicks(1340), new DateTime(2020, 11, 22, 18, 3, 28, 150, DateTimeKind.Local).AddTicks(1758) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(9197), new DateTime(2020, 11, 22, 18, 3, 28, 147, DateTimeKind.Local).AddTicks(9867) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 148, DateTimeKind.Local).AddTicks(357), new DateTime(2020, 11, 22, 18, 3, 28, 148, DateTimeKind.Local).AddTicks(388) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 149, DateTimeKind.Local).AddTicks(1641), new DateTime(2020, 11, 22, 18, 3, 28, 149, DateTimeKind.Local).AddTicks(2134) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 144, DateTimeKind.Local).AddTicks(7371), new DateTime(2020, 11, 22, 18, 3, 28, 145, DateTimeKind.Local).AddTicks(7734) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 11, 22, 18, 3, 28, 145, DateTimeKind.Local).AddTicks(8332), new DateTime(2020, 11, 22, 18, 3, 28, 145, DateTimeKind.Local).AddTicks(8352) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceNumber",
                table: "Invoices");

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
    }
}
