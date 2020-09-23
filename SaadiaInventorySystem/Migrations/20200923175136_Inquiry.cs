using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class Inquiry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inquirys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Ms = table.Column<string>(nullable: true),
                    Attn = table.Column<string>(nullable: true),
                    InquiryNumber = table.Column<string>(nullable: true),
                    Discount = table.Column<double>(nullable: false),
                    DateIssued = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquirys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InquiryItems",
                columns: table => new
                {
                    InquiryId = table.Column<int>(nullable: false),
                    InventoryId = table.Column<int>(nullable: false),
                    OfferedPrice = table.Column<double>(nullable: false),
                    OfferedQty = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    IsActive = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InquiryItems", x => new { x.InquiryId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_InquiryItems_Inquirys_InquiryId",
                        column: x => x.InquiryId,
                        principalTable: "Inquirys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InquiryItems_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Inquirys",
                columns: new[] { "Id", "Attn", "DateCreated", "DateIssued", "DateUpdated", "Discount", "InquiryNumber", "IsActive", "Ms" },
                values: new object[] { 1, "", new DateTime(2020, 9, 23, 20, 51, 35, 916, DateTimeKind.Local).AddTicks(4511), new DateTime(2020, 9, 23, 20, 51, 35, 916, DateTimeKind.Local).AddTicks(4082), new DateTime(2020, 9, 23, 20, 51, 35, 916, DateTimeKind.Local).AddTicks(5099), 0.0, "REQ-01-2020", 1, "" });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(3343), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(3768) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4694), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4710) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4730), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4731) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4734), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4735) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4736), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4747), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4748) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4750), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4751) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4752), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4753) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4755), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4756) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4758), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4759) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4761), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(4762) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 915, DateTimeKind.Local).AddTicks(8571), new DateTime(2020, 9, 23, 20, 51, 35, 915, DateTimeKind.Local).AddTicks(8984) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(7956), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(8401) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(8853), new DateTime(2020, 9, 23, 20, 51, 35, 913, DateTimeKind.Local).AddTicks(8874) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 914, DateTimeKind.Local).AddTicks(9756), new DateTime(2020, 9, 23, 20, 51, 35, 915, DateTimeKind.Local).AddTicks(177) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 910, DateTimeKind.Local).AddTicks(4693), new DateTime(2020, 9, 23, 20, 51, 35, 911, DateTimeKind.Local).AddTicks(6559) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 9, 23, 20, 51, 35, 911, DateTimeKind.Local).AddTicks(7092), new DateTime(2020, 9, 23, 20, 51, 35, 911, DateTimeKind.Local).AddTicks(7112) });

            migrationBuilder.InsertData(
                table: "InquiryItems",
                columns: new[] { "InquiryId", "InventoryId", "DateAdded", "DateUpdated", "IsActive", "OfferedPrice", "OfferedQty", "Total" },
                values: new object[] { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200.0, 3, 600.0 });

            migrationBuilder.InsertData(
                table: "InquiryItems",
                columns: new[] { "InquiryId", "InventoryId", "DateAdded", "DateUpdated", "IsActive", "OfferedPrice", "OfferedQty", "Total" },
                values: new object[] { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200.0, 3, 600.0 });

            migrationBuilder.CreateIndex(
                name: "IX_InquiryItems_InventoryId",
                table: "InquiryItems",
                column: "InventoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InquiryItems");

            migrationBuilder.DropTable(
                name: "Inquirys");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(7162), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(7822) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9222), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9239) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9268), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9274), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9278), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9294), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9296) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9299), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9301) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9304), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9305) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9308), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9317), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9318) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9324), new DateTime(2020, 8, 28, 19, 27, 27, 60, DateTimeKind.Local).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 64, DateTimeKind.Local).AddTicks(8998), new DateTime(2020, 8, 28, 19, 27, 27, 64, DateTimeKind.Local).AddTicks(9924) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 61, DateTimeKind.Local).AddTicks(4100), new DateTime(2020, 8, 28, 19, 27, 27, 61, DateTimeKind.Local).AddTicks(4932) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 61, DateTimeKind.Local).AddTicks(5789), new DateTime(2020, 8, 28, 19, 27, 27, 61, DateTimeKind.Local).AddTicks(5857) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 63, DateTimeKind.Local).AddTicks(4351), new DateTime(2020, 8, 28, 19, 27, 27, 63, DateTimeKind.Local).AddTicks(5023) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 57, DateTimeKind.Local).AddTicks(4203), new DateTime(2020, 8, 28, 19, 27, 27, 58, DateTimeKind.Local).AddTicks(2176) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 8, 28, 19, 27, 27, 58, DateTimeKind.Local).AddTicks(3073), new DateTime(2020, 8, 28, 19, 27, 27, 58, DateTimeKind.Local).AddTicks(3105) });
        }
    }
}
