using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class CustomerOnDeleteUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotations_Customers_CustomerId1",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_CustomerId1",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Quotations");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Quotations",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(4669), new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(5090) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(5977), new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(5988) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6003), new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6004) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6006), new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6007) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6009), new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6010) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6017), new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6018) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6019), new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6020) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6022), new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6023) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6024), new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6028), new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6029) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6031), new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(6032) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(9171), new DateTime(2020, 7, 27, 12, 12, 21, 333, DateTimeKind.Local).AddTicks(9608) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 334, DateTimeKind.Local).AddTicks(46), new DateTime(2020, 7, 27, 12, 12, 21, 334, DateTimeKind.Local).AddTicks(69) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 335, DateTimeKind.Local).AddTicks(395), new DateTime(2020, 7, 27, 12, 12, 21, 335, DateTimeKind.Local).AddTicks(813) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 331, DateTimeKind.Local).AddTicks(5559), new DateTime(2020, 7, 27, 12, 12, 21, 331, DateTimeKind.Local).AddTicks(9126) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 27, 12, 12, 21, 331, DateTimeKind.Local).AddTicks(9649), new DateTime(2020, 7, 27, 12, 12, 21, 331, DateTimeKind.Local).AddTicks(9668) });

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CustomerId1",
                table: "Quotations",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Customers_CustomerId1",
                table: "Quotations",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
