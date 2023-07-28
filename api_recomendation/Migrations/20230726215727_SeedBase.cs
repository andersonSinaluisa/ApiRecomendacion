using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_recomendation.Migrations
{
    /// <inheritdoc />
    public partial class SeedBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "CreatedAt", "Endpoint", "Method", "UpdatedAt" },
                values: new object[,]
                {
                    { 0, "GetAll", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EntityController", "GET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "GetById", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EntityController", "GET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Add", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EntityController", "POST", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "AddMany", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EntityController", "POST", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EntityController", "PUT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Remove", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EntityController", "DELETE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "AddAttribute", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EntityController", "POST", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "UpdateAttribute", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EntityController", "PUT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Save", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileController", "POST", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileController", "GET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Delete", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileController", "DELETE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Train", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileController", "GET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "GetRecomendation", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileController", "GET", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Save", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileController", "POST", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "SaveMany", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileController", "POST", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "DeleteAll", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileController", "DELETE", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "Update", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ProfileController", "PUT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "Login", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AuthController", "POST", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "Register", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AuthController", "POST", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 26, 16, 57, 26, 901, DateTimeKind.Local).AddTicks(9648), "admin", "admin", new DateTime(2023, 7, 26, 16, 57, 26, 901, DateTimeKind.Local).AddTicks(9661) },
                    { 2, new DateTime(2023, 7, 26, 16, 57, 26, 901, DateTimeKind.Local).AddTicks(9664), "user", "user", new DateTime(2023, 7, 26, 16, 57, 26, 901, DateTimeKind.Local).AddTicks(9664) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateJoined", "Email", "IsAdmin", "IsAuthenticated", "IsStaff", "IsSuperUser", "LastLogin", "LastName", "Name", "Password", "RoleId", "UserName" },
                values: new object[] { 1, new DateTime(2023, 7, 26, 16, 57, 27, 37, DateTimeKind.Local).AddTicks(4467), "demo@mail.com", false, false, false, false, new DateTime(2023, 7, 26, 16, 57, 27, 37, DateTimeKind.Local).AddTicks(4481), "demo", "demo", "$2a$10$gl7AsG0C06BIqnpt96NcaeASTbv/nRin6L4e0h9BUtk8AYdYFT1si", 2, "demo" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 0);

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
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
