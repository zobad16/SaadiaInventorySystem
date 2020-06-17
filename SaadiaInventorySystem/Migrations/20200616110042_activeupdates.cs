using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class activeupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: 1);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(988), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(1425) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2790), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2802) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2818), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2819) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2821), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2822) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2824), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2825) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2834), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2834) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2836), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2837) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2839), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2930), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2931) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2936), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2937) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2939), new DateTime(2020, 6, 16, 13, 48, 45, 224, DateTimeKind.Local).AddTicks(2940) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 221, DateTimeKind.Local).AddTicks(5065), new DateTime(2020, 6, 16, 13, 48, 45, 222, DateTimeKind.Local).AddTicks(4599) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 16, 13, 48, 45, 222, DateTimeKind.Local).AddTicks(5134), new DateTime(2020, 6, 16, 13, 48, 45, 222, DateTimeKind.Local).AddTicks(5153) });
        }
    }
}
