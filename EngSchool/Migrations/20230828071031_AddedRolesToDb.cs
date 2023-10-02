using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EngSchool.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "28635b61-d5a2-4cea-90ef-334ed7902255", "17220331-fc30-46c7-adcd-1a70f30485e5", "Учитель", "TEACHER" },
                    { "332d8327-21e3-4bcc-8c38-f2131bbdd8e8", "ddefd8d2-0be1-47c8-babe-b736f15252e2", "Ученик", "STUDENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28635b61-d5a2-4cea-90ef-334ed7902255");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "332d8327-21e3-4bcc-8c38-f2131bbdd8e8");
        }
    }
}
