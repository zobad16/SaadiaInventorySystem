using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class InquiryItemChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_InquiryItems_InquiryItemInquiryId_InquiryItemInv~",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InquiryItemInquiryId_InquiryItemInventoryId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InquiryItemInquiryId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InquiryItemInventoryId",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId1",
                table: "InquiryItems",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "InquiryItemInquiryId",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InquiryItemInventoryId",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Inquirys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateIssued", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 16, DateTimeKind.Local).AddTicks(7249), new DateTime(2020, 10, 13, 13, 36, 49, 16, DateTimeKind.Local).AddTicks(6724), new DateTime(2020, 10, 13, 13, 36, 49, 16, DateTimeKind.Local).AddTicks(7687) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(3805), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(4259) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5327), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5340) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5363), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5364) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5367), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5368) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5370), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5371) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5381), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5382) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5384), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5385) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5387), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5388) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5389), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5390) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5393), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5394) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5397), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(5398) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 16, DateTimeKind.Local).AddTicks(821), new DateTime(2020, 10, 13, 13, 36, 49, 16, DateTimeKind.Local).AddTicks(1267) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(8829), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(9315) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(9808), new DateTime(2020, 10, 13, 13, 36, 49, 13, DateTimeKind.Local).AddTicks(9837) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 15, DateTimeKind.Local).AddTicks(1306), new DateTime(2020, 10, 13, 13, 36, 49, 15, DateTimeKind.Local).AddTicks(1756) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 10, DateTimeKind.Local).AddTicks(5002), new DateTime(2020, 10, 13, 13, 36, 49, 11, DateTimeKind.Local).AddTicks(5761) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 13, 13, 36, 49, 11, DateTimeKind.Local).AddTicks(6352), new DateTime(2020, 10, 13, 13, 36, 49, 11, DateTimeKind.Local).AddTicks(6371) });

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InquiryItemInquiryId_InquiryItemInventoryId",
                table: "Inventories",
                columns: new[] { "InquiryItemInquiryId", "InquiryItemInventoryId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_InquiryItems_InquiryItemInquiryId_InquiryItemInv~",
                table: "Inventories",
                columns: new[] { "InquiryItemInquiryId", "InquiryItemInventoryId" },
                principalTable: "InquiryItems",
                principalColumns: new[] { "InquiryId", "InventoryId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
