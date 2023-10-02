using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EngSchool.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthUserTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e34ba4a-9371-47ad-bf77-8c5652f9ac4a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bfd3d7a-5b3e-4c2a-8707-0cdba8c07c1d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd955dda-92cf-43e0-ae8c-d61b4c03c43b");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUsers",
                newName: "UserID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "AspNetUsers",
                newName: "UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5e34ba4a-9371-47ad-bf77-8c5652f9ac4a", "65c6a4d3-1fbc-4dda-aec6-84b50dc544d5", "Админ", "ADMIN" },
                    { "7bfd3d7a-5b3e-4c2a-8707-0cdba8c07c1d", "4bdbc8fc-7a19-49b4-8824-e9273430325a", "Учитель", "TEACHER" },
                    { "fd955dda-92cf-43e0-ae8c-d61b4c03c43b", "1cfcba75-8962-4125-9289-30ac917be253", "Ученик", "STUDENT" }
                });
        }
    }
}
