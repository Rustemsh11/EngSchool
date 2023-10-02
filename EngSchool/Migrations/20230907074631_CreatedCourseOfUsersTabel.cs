using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EngSchool.Migrations
{
    /// <inheritdoc />
    public partial class CreatedCourseOfUsersTabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "CourseOfUsers",
                columns: table => new
                {
                    CourseOfUsersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOfUsers", x => x.CourseOfUsersId);
                    table.ForeignKey(
                        name: "FK_CourseOfUsers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseOfUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseUser",
                columns: table => new
                {
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUser", x => new { x.CoursesCourseId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_CourseUser_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "267d76ac-f2b1-4a34-af2e-5b6ea5c4dee9", "4b1a1d4f-917c-458f-8940-2fffcb70cf1e", "Учитель", "TEACHER" },
                    { "455db1bc-280d-4c05-8d37-350600aff537", "0d7ad4d5-876b-412c-9e58-792e4e301d56", "Админ", "ADMIN" },
                    { "fcf557cb-4a8b-4734-97fd-29d53bd006b8", "2758c9f5-0796-4159-8dde-114c5961b946", "Ученик", "STUDENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfUsers_CourseId",
                table: "CourseOfUsers",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfUsers_UserId",
                table: "CourseOfUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUser_UsersUserId",
                table: "CourseUser",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseOfUsers");

            migrationBuilder.DropTable(
                name: "CourseUser");

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
    }
}
