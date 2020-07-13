using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SaadiaInventorySystem.Migrations
{
    public partial class QuotationRelationshipChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Quotations_CustomerId_OnetoMany",
                table: "Quotations"
                );
            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CustomerId_OnetoMany",
                table: "Quotations",
                column: "CustomerId"); 

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Quotations_Customers_CustomerId1",
            //    table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_CustomerId",
                table: "Quotations");

            migrationBuilder.DropIndex(
                name: "IX_Quotations_CustomerId1",
                table: "Quotations");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Quotations");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(1327), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(1741) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2669), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2680) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2693), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2694) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2697), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2698) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2699), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2708), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2709) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2710), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2711) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2713), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2714) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2899), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2901) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2905), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2906) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2908), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(2909) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(6176), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(6615) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(7057), new DateTime(2020, 7, 8, 16, 29, 21, 723, DateTimeKind.Local).AddTicks(7079) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 724, DateTimeKind.Local).AddTicks(7694), new DateTime(2020, 7, 8, 16, 29, 21, 724, DateTimeKind.Local).AddTicks(8119) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 721, DateTimeKind.Local).AddTicks(1308), new DateTime(2020, 7, 8, 16, 29, 21, 721, DateTimeKind.Local).AddTicks(5230) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 16, 29, 21, 721, DateTimeKind.Local).AddTicks(5724), new DateTime(2020, 7, 8, 16, 29, 21, 721, DateTimeKind.Local).AddTicks(5741) });

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Quotations_CustomerId",
                table: "Quotations");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Quotations",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(7278), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(7540) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8119), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8130) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8145), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8146) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8148), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8149) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8151), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8160), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8161) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8163), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8164) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8166), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8167) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8168), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8169) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8172), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8173) });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8177), new DateTime(2020, 7, 8, 15, 42, 0, 100, DateTimeKind.Local).AddTicks(8178) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 101, DateTimeKind.Local).AddTicks(1027), new DateTime(2020, 7, 8, 15, 42, 0, 101, DateTimeKind.Local).AddTicks(1316) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 101, DateTimeKind.Local).AddTicks(1591), new DateTime(2020, 7, 8, 15, 42, 0, 101, DateTimeKind.Local).AddTicks(1617) });

            migrationBuilder.UpdateData(
                table: "Quotations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 101, DateTimeKind.Local).AddTicks(9571), new DateTime(2020, 7, 8, 15, 42, 0, 101, DateTimeKind.Local).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 98, DateTimeKind.Local).AddTicks(9378), new DateTime(2020, 7, 8, 15, 42, 0, 99, DateTimeKind.Local).AddTicks(3092) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateUpdate" },
                values: new object[] { new DateTime(2020, 7, 8, 15, 42, 0, 99, DateTimeKind.Local).AddTicks(3430), new DateTime(2020, 7, 8, 15, 42, 0, 99, DateTimeKind.Local).AddTicks(3449) });

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CustomerId",
                table: "Quotations",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotations_CustomerId1",
                table: "Quotations",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotations_Customers_CustomerId1",
                table: "Quotations",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
