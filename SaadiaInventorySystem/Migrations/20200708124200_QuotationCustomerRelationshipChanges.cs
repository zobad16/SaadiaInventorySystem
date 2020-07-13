using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class QuotationCustomerRelationshipChanges : Migration
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
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(7278), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(7540) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8119), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8130) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8145), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8146) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8148), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8149) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8151), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8160), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8161) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8163), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8164) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8166), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8167) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8168), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8169) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8172), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8173) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8177), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8178) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 101, DateTimeKind.Local).AddTicks(1027), new DateTime(2020, 7, 8, 15, 42, 0, 101, DateTimeKind.Local).AddTicks(1316) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 101, DateTimeKind.Local).AddTicks(1591), new DateTime(2020, 7, 8, 15, 42, 0, 101, DateTimeKind.Local).AddTicks(1617) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 101, DateTimeKind.Local).AddTicks(9571), new DateTime(2020, 7, 8, 15, 42, 0, 101, DateTimeKind.Local).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 98, DateTimeKind.Local).AddTicks(9378), new DateTime(2020, 7, 8, 15, 42, 0, 99, DateTimeKind.Local).AddTicks(3092) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 99, DateTimeKind.Local).AddTicks(3430), new DateTime(2020, 7, 8, 15, 42, 0, 99, DateTimeKind.Local).AddTicks(3449) });

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
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(3805), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(4215) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5206), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5218) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5232), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5233) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5235), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5236) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5238), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5239) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5247), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5248) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5250), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5251) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5253), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5254) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5255), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5256) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5259), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5260) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5262), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(5263) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(8381), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(9056) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(9537), new DateTime(2020, 7, 7, 12, 54, 42, 731, DateTimeKind.Local).AddTicks(9566) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 733, DateTimeKind.Local).AddTicks(446), new DateTime(2020, 7, 7, 12, 54, 42, 733, DateTimeKind.Local).AddTicks(868) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 729, DateTimeKind.Local).AddTicks(3864), new DateTime(2020, 7, 7, 12, 54, 42, 729, DateTimeKind.Local).AddTicks(7468) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 729, DateTimeKind.Local).AddTicks(7966), new DateTime(2020, 7, 7, 12, 54, 42, 729, DateTimeKind.Local).AddTicks(7985) });
        }
    }
}
