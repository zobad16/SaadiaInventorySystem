using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class CustomerChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComapnyName",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Customers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyName",
                value: "QTS");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompanyName",
                value: "Saadia");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(3769), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(4235) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5459), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5475) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5493), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5495) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5497), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5498) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5500), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5501) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5510), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5511) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5513), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5513) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5515), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5516) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5518), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5524), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5525) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5528), new DateTime(2020, 6, 17, 19, 5, 13, 554, DateTimeKind.Local).AddTicks(5529) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 551, DateTimeKind.Local).AddTicks(6342), new DateTime(2020, 6, 17, 19, 5, 13, 552, DateTimeKind.Local).AddTicks(6555) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 19, 5, 13, 552, DateTimeKind.Local).AddTicks(7131), new DateTime(2020, 6, 17, 19, 5, 13, 552, DateTimeKind.Local).AddTicks(7154) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "ComapnyName",
                table: "Customers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "ComapnyName",
                value: "QTS");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ComapnyName",
                value: "Saadia");

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
    }
}
