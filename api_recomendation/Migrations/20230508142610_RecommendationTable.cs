using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_recomendation.Migrations
{
    /// <inheritdoc />
    public partial class RecommendationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recommendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    EntityId = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    IsRecommended = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recommendations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recommendations_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recommendations_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "CreatedAt", "Description", "Model", "UpdatedAt" },
                values: new object[,]
                {
                    { 37, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create Recommendation", "Recommendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read Recommendation", "Recommendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update Recommendation", "Recommendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete Recommendation", "Recommendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_EntityId",
                table: "Recommendations",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_ProfileId",
                table: "Recommendations",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recommendations");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 7, 20, 49, 45, 967, DateTimeKind.Local).AddTicks(9620), new DateTime(2023, 5, 7, 20, 49, 45, 967, DateTimeKind.Local).AddTicks(9638) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 5, 7, 20, 49, 45, 967, DateTimeKind.Local).AddTicks(9644), new DateTime(2023, 5, 7, 20, 49, 45, 967, DateTimeKind.Local).AddTicks(9645) });
        }
    }
}
