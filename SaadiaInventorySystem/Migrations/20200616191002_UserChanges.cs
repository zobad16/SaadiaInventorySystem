using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class UserChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(3850), new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(4307) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5283), new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5294) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5314), new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5315) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5318), new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5319) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5321), new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5322) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5331), new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5332) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5333), new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5334) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5336), new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5339), new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5340) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5343), new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5344) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5348), new DateTime(2020, 6, 16, 22, 10, 1, 553, DateTimeKind.Local).AddTicks(5349) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 550, DateTimeKind.Local).AddTicks(6008), new DateTime(2020, 6, 16, 22, 10, 1, 551, DateTimeKind.Local).AddTicks(5658) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 22, 10, 1, 551, DateTimeKind.Local).AddTicks(6221), new DateTime(2020, 6, 16, 22, 10, 1, 551, DateTimeKind.Local).AddTicks(6241) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(3085), new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(3652) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4863), new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4878) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4898), new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4899) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4902), new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4903) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4905), new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4906) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4917), new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4919) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4921), new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4922) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4924), new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4926) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4928), new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4933), new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4938), new DateTime(2020, 6, 16, 14, 0, 42, 213, DateTimeKind.Local).AddTicks(4939) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 210, DateTimeKind.Local).AddTicks(2552), new DateTime(2020, 6, 16, 14, 0, 42, 211, DateTimeKind.Local).AddTicks(3023) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 14, 0, 42, 211, DateTimeKind.Local).AddTicks(3661), new DateTime(2020, 6, 16, 14, 0, 42, 211, DateTimeKind.Local).AddTicks(3694) });
        }
    }
}
