using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class Inventory_Datatype_Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Inventories",
                type: "decimal(16, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 2)");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(5937), new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(6679) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7786), new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7797) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7812), new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7813) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7815), new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7816) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7818), new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7819) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7828), new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7829) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7831), new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7832) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7833), new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7834) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7836), new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7837) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7840), new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7841) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7843), new DateTime(2020, 7, 8, 19, 0, 51, 992, DateTimeKind.Local).AddTicks(7844) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 993, DateTimeKind.Local).AddTicks(1054), new DateTime(2020, 7, 8, 19, 0, 51, 993, DateTimeKind.Local).AddTicks(1502) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 993, DateTimeKind.Local).AddTicks(1949), new DateTime(2020, 7, 8, 19, 0, 51, 993, DateTimeKind.Local).AddTicks(1978) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 994, DateTimeKind.Local).AddTicks(2783), new DateTime(2020, 7, 8, 19, 0, 51, 994, DateTimeKind.Local).AddTicks(3248) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 990, DateTimeKind.Local).AddTicks(5910), new DateTime(2020, 7, 8, 19, 0, 51, 991, DateTimeKind.Local).AddTicks(41) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 19, 0, 51, 991, DateTimeKind.Local).AddTicks(574), new DateTime(2020, 7, 8, 19, 0, 51, 991, DateTimeKind.Local).AddTicks(592) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Inventories",
                type: "decimal(5, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 2)");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(1327), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(1741) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2669), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2680) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2693), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2694) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2697), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2698) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2699), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2708), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2709) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2710), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2711) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2713), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2714) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2899), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2901) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2905), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2906) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2908), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2909) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(6176), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(6615) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(7057), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(7079) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 724, DateTimeKind.Local).AddTicks(7694), new DateTime(2020, 7, 8, 16, 29, 21, 724, DateTimeKind.Local).AddTicks(8119) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 721, DateTimeKind.Local).AddTicks(1308), new DateTime(2020, 7, 8, 16, 29, 21, 721, DateTimeKind.Local).AddTicks(5230) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 721, DateTimeKind.Local).AddTicks(5724), new DateTime(2020, 7, 8, 16, 29, 21, 721, DateTimeKind.Local).AddTicks(5741) });
        }
    }
}
