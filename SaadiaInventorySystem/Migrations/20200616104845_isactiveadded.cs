using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class isactiveadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Roles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdate",
                table: "Roles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Roles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Quotations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Invoices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(988), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(1425) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2790), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2802) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2818), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2821), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2822) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2824), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2825) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2834), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2834) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2836), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2837) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2839), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2930), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2931) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2936), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2937) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2939), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 221, DateTimeKind.Local).AddTicks(5065), new DateTime(2020, 6, 16, 13, 48, 45, 222, DateTimeKind.Local).AddTicks(4599) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 222, DateTimeKind.Local).AddTicks(5134), new DateTime(2020, 6, 16, 13, 48, 45, 222, DateTimeKind.Local).AddTicks(5153) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "DateUpdate",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(6315), new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(6734) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7635), new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7647) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7663), new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7664) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7666), new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7667) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7669), new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7670) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7678), new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7680) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7681), new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7682) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7684), new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7685) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7686), new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7687) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7690), new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7694), new DateTime(2020, 6, 15, 17, 24, 11, 31, DateTimeKind.Local).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 29, DateTimeKind.Local).AddTicks(594), new DateTime(2020, 6, 15, 17, 24, 11, 29, DateTimeKind.Local).AddTicks(9941) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 15, 17, 24, 11, 30, DateTimeKind.Local).AddTicks(465), new DateTime(2020, 6, 15, 17, 24, 11, 30, DateTimeKind.Local).AddTicks(483) });
        }
    }
}
