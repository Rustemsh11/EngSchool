using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EngSchool.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthUserTabel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59a9f717-3625-46e1-94c4-5500b9258523");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa31b18f-df50-440b-ab80-0b5686e10187");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b2adf9-9fa2-44e5-86ee-922afcd5697e");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AspNetUsers");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59a9f717-3625-46e1-94c4-5500b9258523", "ec429370-f422-43e0-937d-5866358250c3", "Учитель", "TEACHER" },
                    { "aa31b18f-df50-440b-ab80-0b5686e10187", "23959e00-465a-4bff-9c1c-7ab36c095668", "Админ", "ADMIN" },
                    { "f9b2adf9-9fa2-44e5-86ee-922afcd5697e", "56af75bd-73d9-442d-a369-082d88b551ff", "Ученик", "STUDENT" }
                });
        }
    }
}
