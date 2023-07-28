using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_recomendation.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableAttrEntityProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeEntityProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AttributeEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeEntityProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeEntityProfiles_AttributeEntities_AttributeEntityId",
                        column: x => x.AttributeEntityId,
                        principalTable: "AttributeEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeEntityProfiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "Model" },
                values: new object[] { "create AttributeEntityProfile", "AttributeEntityProfile" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Description", "Model" },
                values: new object[] { "read AttributeEntityProfile", "AttributeEntityProfile" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "Model" },
                values: new object[] { "update AttributeEntityProfile", "AttributeEntityProfile" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "Model" },
                values: new object[] { "delete AttributeEntityProfile", "AttributeEntityProfile" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "Model" },
                values: new object[] { "create Entity", "Entity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "Model" },
                values: new object[] { "read Entity", "Entity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "Model" },
                values: new object[] { "update Entity", "Entity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "Model" },
                values: new object[] { "delete Entity", "Entity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Description", "Model" },
                values: new object[] { "create Profile", "Profile" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Description", "Model" },
                values: new object[] { "read Profile", "Profile" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Description", "Model" },
                values: new object[] { "update Profile", "Profile" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Description", "Model" },
                values: new object[] { "delete Profile", "Profile" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Description", "Model" },
                values: new object[] { "create ProfileEntity", "ProfileEntity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Description", "Model" },
                values: new object[] { "read ProfileEntity", "ProfileEntity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Description", "Model" },
                values: new object[] { "update ProfileEntity", "ProfileEntity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Description", "Model" },
                values: new object[] { "delete ProfileEntity", "ProfileEntity" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "CreatedAt", "Description", "Model", "UpdatedAt" },
                values: new object[,]
                {
                    { 41, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create Recommendation", "Recommendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read Recommendation", "Recommendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update Recommendation", "Recommendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete Recommendation", "Recommendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AttributeEntityProfiles_AttributeEntityId",
                table: "AttributeEntityProfiles",
                column: "AttributeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeEntityProfiles_ProfileId",
                table: "AttributeEntityProfiles",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeEntityProfiles");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Description", "Model" },
                values: new object[] { "create Entity", "Entity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Description", "Model" },
                values: new object[] { "read Entity", "Entity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Description", "Model" },
                values: new object[] { "update Entity", "Entity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Description", "Model" },
                values: new object[] { "delete Entity", "Entity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Description", "Model" },
                values: new object[] { "create Profile", "Profile" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Description", "Model" },
                values: new object[] { "read Profile", "Profile" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "Model" },
                values: new object[] { "update Profile", "Profile" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "Model" },
                values: new object[] { "delete Profile", "Profile" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Description", "Model" },
                values: new object[] { "create ProfileEntity", "ProfileEntity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Description", "Model" },
                values: new object[] { "read ProfileEntity", "ProfileEntity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Description", "Model" },
                values: new object[] { "update ProfileEntity", "ProfileEntity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Description", "Model" },
                values: new object[] { "delete ProfileEntity", "ProfileEntity" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "Description", "Model" },
                values: new object[] { "create Recommendation", "Recommendation" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "Description", "Model" },
                values: new object[] { "read Recommendation", "Recommendation" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "Description", "Model" },
                values: new object[] { "update Recommendation", "Recommendation" });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Description", "Model" },
                values: new object[] { "delete Recommendation", "Recommendation" });

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
    }
}
