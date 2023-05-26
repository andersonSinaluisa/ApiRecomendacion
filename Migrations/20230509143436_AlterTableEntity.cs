using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_recomendation.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Entities",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 9, 9, 34, 36, 180, DateTimeKind.Local).AddTicks(7796), new DateTime(2023, 5, 9, 9, 34, 36, 180, DateTimeKind.Local).AddTicks(7807) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 9, 9, 34, 36, 180, DateTimeKind.Local).AddTicks(7810), new DateTime(2023, 5, 9, 9, 34, 36, 180, DateTimeKind.Local).AddTicks(7811) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "Entities");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 8, 12, 7, 44, 679, DateTimeKind.Local).AddTicks(5460), new DateTime(2023, 5, 8, 12, 7, 44, 679, DateTimeKind.Local).AddTicks(5471) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 8, 12, 7, 44, 679, DateTimeKind.Local).AddTicks(5475), new DateTime(2023, 5, 8, 12, 7, 44, 679, DateTimeKind.Local).AddTicks(5476) });
        }
    }
}
