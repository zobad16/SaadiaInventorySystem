using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class inquiryChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Inquirys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Inquirys",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Inquirys");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Inquirys");

            migrationBuilder.UpdateData(
                table: "Inquirys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateIssued", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 916, DateTimeKind.Local).AddTicks(4511), new DateTime(2020, 9, 23, 20, 51, 35, 916, DateTimeKind.Local).AddTicks(4082), new DateTime(2020, 9, 23, 20, 51, 35, 916, DateTimeKind.Local).AddTicks(5099) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(3343), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(3768) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4694), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4710) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4730), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4731) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4734), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4735) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4736), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4747), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4748) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4750), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4751) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4752), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4753) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4755), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4756) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4758), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4759) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4761), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4762) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 915, DateTimeKind.Local).AddTicks(8571), new DateTime(2020, 9, 23, 20, 51, 35, 915, DateTimeKind.Local).AddTicks(8984) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(7956), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(8401) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(8853), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(8874) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 914, DateTimeKind.Local).AddTicks(9756), new DateTime(2020, 9, 23, 20, 51, 35, 915, DateTimeKind.Local).AddTicks(177) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 910, DateTimeKind.Local).AddTicks(4693), new DateTime(2020, 9, 23, 20, 51, 35, 911, DateTimeKind.Local).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 911, DateTimeKind.Local).AddTicks(7092), new DateTime(2020, 9, 23, 20, 51, 35, 911, DateTimeKind.Local).AddTicks(7112) });
        }
    }
}
