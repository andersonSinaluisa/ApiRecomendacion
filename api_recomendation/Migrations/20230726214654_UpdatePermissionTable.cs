using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_recomendation.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePermissionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 36);

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

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Permissions",
                newName: "Method");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Permissions",
                newName: "Endpoint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Method",
                table: "Permissions",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "Endpoint",
                table: "Permissions",
                newName: "Description");

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
                    { 13, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create Token", "Token", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read Token", "Token", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update Token", "Token", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete Token", "Token", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create User", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read User", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update User", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete User", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create AttributeEntity", "AttributeEntity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read AttributeEntity", "AttributeEntity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update AttributeEntity", "AttributeEntity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete AttributeEntity", "AttributeEntity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create AttributeEntityProfile", "AttributeEntityProfile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read AttributeEntityProfile", "AttributeEntityProfile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update AttributeEntityProfile", "AttributeEntityProfile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete AttributeEntityProfile", "AttributeEntityProfile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create Entity", "Entity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read Entity", "Entity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update Entity", "Entity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete Entity", "Entity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create Profile", "Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read Profile", "Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update Profile", "Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete Profile", "Profile", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create ProfileEntity", "ProfileEntity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read ProfileEntity", "ProfileEntity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update ProfileEntity", "ProfileEntity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete ProfileEntity", "ProfileEntity", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, "create", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "create Recommendation", "Recommendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, "read", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "read Recommendation", "Recommendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, "update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "update Recommendation", "Recommendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, "delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "delete Recommendation", "Recommendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 9, 9, 34, 36, 180, DateTimeKind.Local).AddTicks(7796), "admin", "admin", new DateTime(2023, 5, 9, 9, 34, 36, 180, DateTimeKind.Local).AddTicks(7807) },
                    { 2, new DateTime(2023, 5, 9, 9, 34, 36, 180, DateTimeKind.Local).AddTicks(7810), "user", "user", new DateTime(2023, 5, 9, 9, 34, 36, 180, DateTimeKind.Local).AddTicks(7811) }
                });
        }
    }
}
