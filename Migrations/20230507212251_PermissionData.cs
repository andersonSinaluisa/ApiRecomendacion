using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_recomendation.Migrations
{
    /// <inheritdoc />
    public partial class PermissionData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "CreatedAt", "Description", "Model", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create Permission", "Permission", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read Permission", "Permission", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update Permission", "Permission", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete Permission", "Permission", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create PermissionRole", "PermissionRole", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read PermissionRole", "PermissionRole", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update PermissionRole", "PermissionRole", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete PermissionRole", "PermissionRole", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create Role", "Role", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read Role", "Role", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update Role", "Role", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete Role", "Role", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create User", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read User", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update User", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete User", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create AttributeEntity", "AttributeEntity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read AttributeEntity", "AttributeEntity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update AttributeEntity", "AttributeEntity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete AttributeEntity", "AttributeEntity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create Entity", "Entity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read Entity", "Entity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update Entity", "Entity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete Entity", "Entity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
