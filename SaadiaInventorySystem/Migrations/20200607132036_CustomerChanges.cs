using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class CustomerChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Customers_CustomerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CustomerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Inventories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdate",
                table: "Inventories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "Inventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate", "FirstName", "LastName" },
                values: new object[] { new DateTime(2020, 6, 7, 16, 20, 36, 138, DateTimeKind.Local).AddTicks(4453), new DateTime(2020, 6, 7, 16, 20, 36, 139, DateTimeKind.Local).AddTicks(5768), "Zobad", "Mahmood" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate", "FirstName", "LastName" },
                values: new object[] { new DateTime(2020, 6, 7, 16, 20, 36, 139, DateTimeKind.Local).AddTicks(6313), new DateTime(2020, 6, 7, 16, 20, 36, 139, DateTimeKind.Local).AddTicks(6334), "Hamza", "Sheikh" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "DateUpdate",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CustomerId", "DateCreated", "DateUpdate" },
                values: new object[] { 1, new DateTime(2020, 6, 2, 13, 41, 23, 764, DateTimeKind.Local).AddTicks(5765), new DateTime(2020, 6, 2, 13, 41, 23, 765, DateTimeKind.Local).AddTicks(7242) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CustomerId", "DateCreated", "DateUpdate" },
                values: new object[] { 2, new DateTime(2020, 6, 2, 13, 41, 23, 765, DateTimeKind.Local).AddTicks(7785), new DateTime(2020, 6, 2, 13, 41, 23, 765, DateTimeKind.Local).AddTicks(7804) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerId",
                table: "Users",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Customers_CustomerId",
                table: "Users",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
