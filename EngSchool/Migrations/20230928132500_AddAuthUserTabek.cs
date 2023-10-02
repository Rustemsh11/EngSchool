using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EngSchool.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthUserTabek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "267d76ac-f2b1-4a34-af2e-5b6ea5c4dee9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "455db1bc-280d-4c05-8d37-350600aff537");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcf557cb-4a8b-4734-97fd-29d53bd006b8");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "267d76ac-f2b1-4a34-af2e-5b6ea5c4dee9", "4b1a1d4f-917c-458f-8940-2fffcb70cf1e", "Учитель", "TEACHER" },
                    { "455db1bc-280d-4c05-8d37-350600aff537", "0d7ad4d5-876b-412c-9e58-792e4e301d56", "Админ", "ADMIN" },
                    { "fcf557cb-4a8b-4734-97fd-29d53bd006b8", "2758c9f5-0796-4159-8dde-114c5961b946", "Ученик", "STUDENT" }
                });
        }
    }
}
