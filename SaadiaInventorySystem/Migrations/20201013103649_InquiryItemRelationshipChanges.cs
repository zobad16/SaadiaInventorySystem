using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class InquiryItemRelationshipChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InquiryItemInquiryId",
                table: "Inventories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InquiryItemInventoryId",
                table: "Inventories",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Inquirys",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateIssued", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 647, DateTimeKind.Local).AddTicks(2585), new DateTime(2020, 10, 5, 9, 59, 22, 647, DateTimeKind.Local).AddTicks(2069), new DateTime(2020, 10, 5, 9, 59, 22, 647, DateTimeKind.Local).AddTicks(3070) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 642, DateTimeKind.Local).AddTicks(9783), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(343) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2351), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2373) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2481), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2486) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2493), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2497) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2502), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2506) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2522), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2526) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2532), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2535) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2541), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2544) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2550), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2553) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2562), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2566) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2573), new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(2577) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 646, DateTimeKind.Local).AddTicks(5304), new DateTime(2020, 10, 5, 9, 59, 22, 646, DateTimeKind.Local).AddTicks(5761) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 643, DateTimeKind.Local).AddTicks(9504), new DateTime(2020, 10, 5, 9, 59, 22, 644, DateTimeKind.Local).AddTicks(99) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 644, DateTimeKind.Local).AddTicks(887), new DateTime(2020, 10, 5, 9, 59, 22, 644, DateTimeKind.Local).AddTicks(919) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 645, DateTimeKind.Local).AddTicks(4578), new DateTime(2020, 10, 5, 9, 59, 22, 645, DateTimeKind.Local).AddTicks(5113) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 639, DateTimeKind.Local).AddTicks(4487), new DateTime(2020, 10, 5, 9, 59, 22, 640, DateTimeKind.Local).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 10, 5, 9, 59, 22, 640, DateTimeKind.Local).AddTicks(6919), new DateTime(2020, 10, 5, 9, 59, 22, 640, DateTimeKind.Local).AddTicks(6943) });
        }
    }
}
