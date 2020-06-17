using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class rolechanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleFk",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleFk",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "RoleFk",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(2845), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(3262) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4159), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4169) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4184), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4184) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4186), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4187) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4189), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4197), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4198) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4199), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4200) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4202), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4203) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4204), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4205) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4208), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4209) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4211), new DateTime(2020, 6, 17, 11, 28, 29, 943, DateTimeKind.Local).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 940, DateTimeKind.Local).AddTicks(7353), new DateTime(2020, 6, 17, 11, 28, 29, 941, DateTimeKind.Local).AddTicks(7402) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 6, 17, 11, 28, 29, 941, DateTimeKind.Local).AddTicks(7916), new DateTime(2020, 6, 17, 11, 28, 29, 941, DateTimeKind.Local).AddTicks(7934) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleFk",
                table: "Users",
                column: "RoleFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleFk",
                table: "Users",
                column: "RoleFk",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleFk",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleFk",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "RoleFk",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleFk",
                table: "Users",
                column: "RoleFk",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleFk",
                table: "Users",
                column: "RoleFk",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
