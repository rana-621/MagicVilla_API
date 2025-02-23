using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_VillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class toSolveErrorCastingFromIntToDouble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "Villas",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2025, 2, 23, 17, 31, 9, 813, DateTimeKind.Local).AddTicks(9267), 200.0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2025, 2, 23, 17, 31, 9, 813, DateTimeKind.Local).AddTicks(9320), 300.0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2025, 2, 23, 17, 31, 9, 813, DateTimeKind.Local).AddTicks(9322), 400.0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2025, 2, 23, 17, 31, 9, 813, DateTimeKind.Local).AddTicks(9324), 550.0 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2025, 2, 23, 17, 31, 9, 813, DateTimeKind.Local).AddTicks(9325), 600.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "Villas",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2025, 2, 23, 17, 6, 11, 294, DateTimeKind.Local).AddTicks(950), 200 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2025, 2, 23, 17, 6, 11, 294, DateTimeKind.Local).AddTicks(1007), 300 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2025, 2, 23, 17, 6, 11, 294, DateTimeKind.Local).AddTicks(1009), 400 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2025, 2, 23, 17, 6, 11, 294, DateTimeKind.Local).AddTicks(1011), 550 });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Rate" },
                values: new object[] { new DateTime(2025, 2, 23, 17, 6, 11, 294, DateTimeKind.Local).AddTicks(1014), 600 });
        }
    }
}
