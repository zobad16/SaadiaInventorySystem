using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class Inventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "OldParts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdate",
                table: "OldParts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "OldParts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(4793), new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(5212) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6115), new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6126) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6141), new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6142) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6144), new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6144) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6146), new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6147) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6155), new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6156) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6158), new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6159) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6160), new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6161) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6163), new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6164) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6167), new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6168) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6170), new DateTime(2020, 6, 17, 14, 23, 23, 816, DateTimeKind.Local).AddTicks(6171) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 813, DateTimeKind.Local).AddTicks(9232), new DateTime(2020, 6, 17, 14, 23, 23, 814, DateTimeKind.Local).AddTicks(8251) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 14, 23, 23, 814, DateTimeKind.Local).AddTicks(8781), new DateTime(2020, 6, 17, 14, 23, 23, 814, DateTimeKind.Local).AddTicks(8801) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "OldParts");

            migrationBuilder.DropColumn(
                name: "DateUpdate",
                table: "OldParts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "OldParts");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(2845), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(3262) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4159), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4169) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4184), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4184) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4186), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4189), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4197), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4198) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4199), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4200) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4202), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4203) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4204), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4205) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4208), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4211), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 940, DateTimeKind.Local).AddTicks(7353), new DateTime(2020, 6, 17, 11, 28, 29, 941, DateTimeKind.Local).AddTicks(7402) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 941, DateTimeKind.Local).AddTicks(7916), new DateTime(2020, 6, 17, 11, 28, 29, 941, DateTimeKind.Local).AddTicks(7934) });
        }
    }
}
