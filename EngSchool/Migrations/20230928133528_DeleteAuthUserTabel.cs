using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EngSchool.Migrations
{
    /// <inheritdoc />
    public partial class DeleteAuthUserTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80f80e09-bb40-4c5b-9790-071781720c7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aa37d6c-26d6-4da4-a5f8-958d0159a929");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d531cd53-62cf-4a0f-a68d-769b1d5b5e00");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ef9d49e-3738-4dd9-96c0-c3ad050872fa", "4dcde648-e617-482f-85c6-fdd2ebc89e90", "Ученик", "STUDENT" },
                    { "6ef866f2-d123-4d03-9199-b648adf9689e", "d3b15424-db14-49bf-9da9-b7ba12919f91", "Админ", "ADMIN" },
                    { "95e37d41-cf99-4fa5-b5b9-d1868d19dbe8", "e0f4e6a2-4627-4363-9cf8-174613b63463", "Учитель", "TEACHER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ef9d49e-3738-4dd9-96c0-c3ad050872fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ef866f2-d123-4d03-9199-b648adf9689e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95e37d41-cf99-4fa5-b5b9-d1868d19dbe8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80f80e09-bb40-4c5b-9790-071781720c7e", "d0dd79de-1486-47c1-86d6-dc81dc34ba78", "Админ", "ADMIN" },
                    { "9aa37d6c-26d6-4da4-a5f8-958d0159a929", "c9104017-b083-4cd9-a5d9-443ad12538b0", "Учитель", "TEACHER" },
                    { "d531cd53-62cf-4a0f-a68d-769b1d5b5e00", "08e83d5d-9988-4129-8cd7-bc77c717c51c", "Ученик", "STUDENT" }
                });
        }
    }
}
