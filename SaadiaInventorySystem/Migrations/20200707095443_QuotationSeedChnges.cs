using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class QuotationSeedChnges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "DateCreated", "DateUpdated", "Message", "Note" },
                values: new object[] { new DateTime(2020, 7, 7, 12, 54, 42, 733, DateTimeKind.Local).AddTicks(446), new DateTime(2020, 7, 7, 12, 54, 42, 733, DateTimeKind.Local).AddTicks(868), "Dear Sir.Thank you for your inquiry. We are pleased to quote our best prices as follows:", @"Delivery: 5 days on order confirmation., Price quoted Net in UAE Dirhams, ex-warehouse.
Make: Genuine Part
Validity: 1 week 
Payment: 100% cash on order confirmation.
Awaiting your valued order & assuring you of our best services always." });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 891, DateTimeKind.Local).AddTicks(8060), new DateTime(2020, 7, 2, 13, 3, 48, 891, DateTimeKind.Local).AddTicks(8960) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1106), new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1133) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1176), new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1181) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1188), new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1192) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1198), new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1203) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1223), new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1225) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1232), new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1236) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1243), new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1248) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1275), new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1279) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1289), new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1291) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1298), new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(8679), new DateTime(2020, 7, 2, 13, 3, 48, 892, DateTimeKind.Local).AddTicks(9342) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 893, DateTimeKind.Local).AddTicks(32), new DateTime(2020, 7, 2, 13, 3, 48, 893, DateTimeKind.Local).AddTicks(77) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated", "Message", "Note" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 894, DateTimeKind.Local).AddTicks(8592), new DateTime(2020, 7, 2, 13, 3, 48, 894, DateTimeKind.Local).AddTicks(9266), @"Delivery: 5 days on order confirmation., Price quoted Net in UAE Dirhams, ex-warehouse.
Make: Genuine Part
Validity: 1 week 
Payment: 100% cash on order confirmation.
Awaiting your valued order & assuring you of our best services always.", "Dear Sir.Thank you for your inquiry. We are pleased to quote our best prices as follows:" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 885, DateTimeKind.Local).AddTicks(9451), new DateTime(2020, 7, 2, 13, 3, 48, 887, DateTimeKind.Local).AddTicks(1957) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 887, DateTimeKind.Local).AddTicks(3224), new DateTime(2020, 7, 2, 13, 3, 48, 887, DateTimeKind.Local).AddTicks(3269) });
        }
    }
}
