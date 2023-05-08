using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_recomendation.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRecommendationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAccepted",
                table: "Recommendations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 8, 9, 44, 47, 273, DateTimeKind.Local).AddTicks(8084), new DateTime(2023, 5, 8, 9, 44, 47, 273, DateTimeKind.Local).AddTicks(8101) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 8, 9, 44, 47, 273, DateTimeKind.Local).AddTicks(8106), new DateTime(2023, 5, 8, 9, 44, 47, 273, DateTimeKind.Local).AddTicks(8107) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccepted",
                table: "Recommendations");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 8, 9, 26, 10, 598, DateTimeKind.Local).AddTicks(1773), new DateTime(2023, 5, 8, 9, 26, 10, 598, DateTimeKind.Local).AddTicks(1784) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 8, 9, 26, 10, 598, DateTimeKind.Local).AddTicks(1787), new DateTime(2023, 5, 8, 9, 26, 10, 598, DateTimeKind.Local).AddTicks(1788) });
        }
    }
}
