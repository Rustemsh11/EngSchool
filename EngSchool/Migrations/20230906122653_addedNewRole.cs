using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EngSchool.Migrations
{
    /// <inheritdoc />
    public partial class addedNewRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28635b61-d5a2-4cea-90ef-334ed7902255");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332d8327-21e3-4bcc-8c38-f2131bbdd8e8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "98586789-5d64-4d32-9c82-2c444ce8711f", "079545c7-3aff-45fc-a31a-c316995f3346", "Ученик", "STUDENT" },
                    { "caf069c6-8e5d-4825-ba0d-b15aa714c518", "e9ea9135-20cf-4085-ae13-1dc53c8988b0", "Учитель", "TEACHER" },
                    { "cecac8a2-4d17-4b02-ab26-396e1c05e07f", "61365ab5-f7d6-4b26-9ca8-350f5dd17a72", "Админ", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98586789-5d64-4d32-9c82-2c444ce8711f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caf069c6-8e5d-4825-ba0d-b15aa714c518");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cecac8a2-4d17-4b02-ab26-396e1c05e07f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28635b61-d5a2-4cea-90ef-334ed7902255", "17220331-fc30-46c7-adcd-1a70f30485e5", "Учитель", "TEACHER" },
                    { "332d8327-21e3-4bcc-8c38-f2131bbdd8e8", "ddefd8d2-0be1-47c8-babe-b736f15252e2", "Ученик", "STUDENT" }
                });
        }
    }
}
