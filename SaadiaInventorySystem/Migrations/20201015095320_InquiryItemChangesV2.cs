using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class InquiryItemChangesV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InquiryItems_Inventories_InventoryId1",
                table: "InquiryItems");

            migrationBuilder.DropIndex(
                name: "IX_InquiryItems_InventoryId1",
                table: "InquiryItems");

            migrationBuilder.DropColumn(
                name: "InventoryId1",
                table: "InquiryItems");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "InquiryItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Inquirys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateIssued", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 55, DateTimeKind.Local).AddTicks(5664), new DateTime(2020, 10, 15, 12, 53, 20, 55, DateTimeKind.Local).AddTicks(5170), new DateTime(2020, 10, 15, 12, 53, 20, 55, DateTimeKind.Local).AddTicks(6271) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 51, DateTimeKind.Local).AddTicks(9997), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(486) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1598), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1609) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1626), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1628) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1630), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1631) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1634), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1643), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1644) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1646), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1648) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1649), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1651) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1652), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1725), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1726) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1730), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(1731) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 54, DateTimeKind.Local).AddTicks(8733), new DateTime(2020, 10, 15, 12, 53, 20, 54, DateTimeKind.Local).AddTicks(9212) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(5282), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(5801) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(6330), new DateTime(2020, 10, 15, 12, 53, 20, 52, DateTimeKind.Local).AddTicks(6357) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 53, DateTimeKind.Local).AddTicks(8542), new DateTime(2020, 10, 15, 12, 53, 20, 53, DateTimeKind.Local).AddTicks(9036) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 49, DateTimeKind.Local).AddTicks(2319), new DateTime(2020, 10, 15, 12, 53, 20, 50, DateTimeKind.Local).AddTicks(1888) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 53, 20, 50, DateTimeKind.Local).AddTicks(2507), new DateTime(2020, 10, 15, 12, 53, 20, 50, DateTimeKind.Local).AddTicks(2548) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "InquiryItems");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId1",
                table: "InquiryItems",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Inquirys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateIssued", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 776, DateTimeKind.Local).AddTicks(966), new DateTime(2020, 10, 15, 12, 17, 17, 776, DateTimeKind.Local).AddTicks(557), new DateTime(2020, 10, 15, 12, 17, 17, 776, DateTimeKind.Local).AddTicks(1348) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(514), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(916) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1795), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1806) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1822), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1823) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1825), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1826) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1827), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1829) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1838), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1839) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1840), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1841) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1843), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1844) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1845), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1846) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1849), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1850) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1852), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(1853) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 775, DateTimeKind.Local).AddTicks(5206), new DateTime(2020, 10, 15, 12, 17, 17, 775, DateTimeKind.Local).AddTicks(5597) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(4935), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(5397) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(5875), new DateTime(2020, 10, 15, 12, 17, 17, 773, DateTimeKind.Local).AddTicks(5904) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 774, DateTimeKind.Local).AddTicks(6929), new DateTime(2020, 10, 15, 12, 17, 17, 774, DateTimeKind.Local).AddTicks(7333) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 770, DateTimeKind.Local).AddTicks(6872), new DateTime(2020, 10, 15, 12, 17, 17, 771, DateTimeKind.Local).AddTicks(5273) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 15, 12, 17, 17, 771, DateTimeKind.Local).AddTicks(5792), new DateTime(2020, 10, 15, 12, 17, 17, 771, DateTimeKind.Local).AddTicks(5837) });

            migrationBuilder.CreateIndex(
                name: "IX_InquiryItems_InventoryId1",
                table: "InquiryItems",
                column: "InventoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InquiryItems_Inventories_InventoryId1",
                table: "InquiryItems",
                column: "InventoryId1",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
