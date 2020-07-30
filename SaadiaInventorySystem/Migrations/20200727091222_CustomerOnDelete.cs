using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class CustomerOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Quotations",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
