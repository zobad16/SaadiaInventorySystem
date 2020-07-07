using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class ChangesToQuotationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 2, 13, 3, 48, 894, DateTimeKind.Local).AddTicks(8592), new DateTime(2020, 7, 2, 13, 3, 48, 894, DateTimeKind.Local).AddTicks(9266) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(6057), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(6503) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7500), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7512) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7529), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7530) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7532), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7532) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7534), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7535) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7544), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7544) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7546), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7547) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7549), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7550) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7552), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7553) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7556), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7557) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7559), new DateTime(2020, 7, 1, 19, 7, 3, 68, DateTimeKind.Local).AddTicks(7560) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 69, DateTimeKind.Local).AddTicks(1027), new DateTime(2020, 7, 1, 19, 7, 3, 69, DateTimeKind.Local).AddTicks(1499) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 69, DateTimeKind.Local).AddTicks(1974), new DateTime(2020, 7, 1, 19, 7, 3, 69, DateTimeKind.Local).AddTicks(2000) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 70, DateTimeKind.Local).AddTicks(2950), new DateTime(2020, 7, 1, 19, 7, 3, 70, DateTimeKind.Local).AddTicks(3405) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 66, DateTimeKind.Local).AddTicks(5888), new DateTime(2020, 7, 1, 19, 7, 3, 66, DateTimeKind.Local).AddTicks(9852) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 1, 19, 7, 3, 67, DateTimeKind.Local).AddTicks(348), new DateTime(2020, 7, 1, 19, 7, 3, 67, DateTimeKind.Local).AddTicks(365) });
        }
    }
}
