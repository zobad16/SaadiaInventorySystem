using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class CustomerOnDeleteUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Quotations_Customers_CustomerId",
            //    table: "Quotations");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Quotations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(424), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(836) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1735), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1746) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1762), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1763) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1765), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1766) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1768), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1769) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1776), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1777) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1779), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1779) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1781), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1782) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1784), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1785) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1788), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1789) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1790), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(1791) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(4851), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(5285) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(5743), new DateTime(2020, 7, 27, 13, 9, 30, 139, DateTimeKind.Local).AddTicks(5769) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 140, DateTimeKind.Local).AddTicks(6254), new DateTime(2020, 7, 27, 13, 9, 30, 140, DateTimeKind.Local).AddTicks(6665) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 137, DateTimeKind.Local).AddTicks(322), new DateTime(2020, 7, 27, 13, 9, 30, 137, DateTimeKind.Local).AddTicks(3954) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 13, 9, 30, 137, DateTimeKind.Local).AddTicks(4465), new DateTime(2020, 7, 27, 13, 9, 30, 137, DateTimeKind.Local).AddTicks(4484) });

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Customers_CustomerId",
                table: "Quotations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Customers_CustomerId",
                table: "Quotations");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Quotations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(1414), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(1833) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2727), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2739) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2754), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2755) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2757), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2758) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2759), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2761) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2768), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2769) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2770), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2771) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2773), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2774) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2815), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2816) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2820), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2821) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2824), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(2825) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(5917), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(6350) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(6793), new DateTime(2020, 7, 27, 12, 42, 55, 923, DateTimeKind.Local).AddTicks(6819) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 924, DateTimeKind.Local).AddTicks(7107), new DateTime(2020, 7, 27, 12, 42, 55, 924, DateTimeKind.Local).AddTicks(7533) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 921, DateTimeKind.Local).AddTicks(1702), new DateTime(2020, 7, 27, 12, 42, 55, 921, DateTimeKind.Local).AddTicks(5389) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 42, 55, 921, DateTimeKind.Local).AddTicks(5913), new DateTime(2020, 7, 27, 12, 42, 55, 921, DateTimeKind.Local).AddTicks(5931) });

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Customers_CustomerId",
                table: "Quotations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
