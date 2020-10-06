using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class InquiryVat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Vat",
                table: "Inquirys",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "VatPercent",
                table: "Inquirys",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Inquirys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateIssued", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 647, DateTimeKind.Local).AddTicks(2585), new DateTime(2020, 10, 5, 9, 59, 22, 647, DateTimeKind.Local).AddTicks(2069), new DateTime(2020, 10, 5, 9, 59, 22, 647, DateTimeKind.Local).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 642, DateTimeKind.Local).AddTicks(9783), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(343) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2351), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2373) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2481), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2486) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2493), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2497) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2502), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2522), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2526) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2532), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2535) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2541), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2544) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2550), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2553) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2562), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2566) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2573), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2577) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 646, DateTimeKind.Local).AddTicks(5304), new DateTime(2020, 10, 5, 9, 59, 22, 646, DateTimeKind.Local).AddTicks(5761) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(9504), new DateTime(2020, 10, 5, 9, 59, 22, 644, DateTimeKind.Local).AddTicks(99) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 644, DateTimeKind.Local).AddTicks(887), new DateTime(2020, 10, 5, 9, 59, 22, 644, DateTimeKind.Local).AddTicks(919) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 645, DateTimeKind.Local).AddTicks(4578), new DateTime(2020, 10, 5, 9, 59, 22, 645, DateTimeKind.Local).AddTicks(5113) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 639, DateTimeKind.Local).AddTicks(4487), new DateTime(2020, 10, 5, 9, 59, 22, 640, DateTimeKind.Local).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 640, DateTimeKind.Local).AddTicks(6919), new DateTime(2020, 10, 5, 9, 59, 22, 640, DateTimeKind.Local).AddTicks(6943) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vat",
                table: "Inquirys");

            migrationBuilder.DropColumn(
                name: "VatPercent",
                table: "Inquirys");

            migrationBuilder.UpdateData(
                table: "Inquirys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateIssued", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 452, DateTimeKind.Local).AddTicks(8649), new DateTime(2020, 9, 30, 20, 36, 15, 452, DateTimeKind.Local).AddTicks(8188), new DateTime(2020, 9, 30, 20, 36, 15, 452, DateTimeKind.Local).AddTicks(9081) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(5208), new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(5672) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6663), new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6675) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6691), new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6693) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6695), new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6696) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6698), new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6699) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6709), new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6711), new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6713) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6714), new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6715) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6717), new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6718) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6721), new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6722) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6726), new DateTime(2020, 9, 30, 20, 36, 15, 449, DateTimeKind.Local).AddTicks(6727) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 452, DateTimeKind.Local).AddTicks(2290), new DateTime(2020, 9, 30, 20, 36, 15, 452, DateTimeKind.Local).AddTicks(2733) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 450, DateTimeKind.Local).AddTicks(236), new DateTime(2020, 9, 30, 20, 36, 15, 450, DateTimeKind.Local).AddTicks(815) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 450, DateTimeKind.Local).AddTicks(1308), new DateTime(2020, 9, 30, 20, 36, 15, 450, DateTimeKind.Local).AddTicks(1339) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 451, DateTimeKind.Local).AddTicks(2703), new DateTime(2020, 9, 30, 20, 36, 15, 451, DateTimeKind.Local).AddTicks(3156) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 446, DateTimeKind.Local).AddTicks(7479), new DateTime(2020, 9, 30, 20, 36, 15, 447, DateTimeKind.Local).AddTicks(7545) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 30, 20, 36, 15, 447, DateTimeKind.Local).AddTicks(8125), new DateTime(2020, 9, 30, 20, 36, 15, 447, DateTimeKind.Local).AddTicks(8146) });
        }
    }
}
