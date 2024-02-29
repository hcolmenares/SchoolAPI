using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seremuevenlasreferencias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_professors_ProfessorId",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_courses_schools_SchoolId",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_professors_schools_SchoolId",
                table: "professors");

            migrationBuilder.DropForeignKey(
                name: "FK_students_schools_SchoolId",
                table: "students");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropIndex(
                name: "IX_students_SchoolId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_professors_SchoolId",
                table: "professors");

            migrationBuilder.DropIndex(
                name: "IX_courses_ProfessorId",
                table: "courses");

            migrationBuilder.DropIndex(
                name: "IX_courses_SchoolId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "professors");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SchoolId",
                table: "students",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolId",
                table: "professors",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfessorId",
                table: "courses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SchoolId",
                table: "courses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CourseId = table.Column<string>(type: "TEXT", nullable: false),
                    StudentId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCourse_courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_students_SchoolId",
                table: "students",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_professors_SchoolId",
                table: "professors",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_ProfessorId",
                table: "courses",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_courses_SchoolId",
                table: "courses",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentId",
                table: "StudentCourse",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_professors_ProfessorId",
                table: "courses",
                column: "ProfessorId",
                principalTable: "professors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_courses_schools_SchoolId",
                table: "courses",
                column: "SchoolId",
                principalTable: "schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_professors_schools_SchoolId",
                table: "professors",
                column: "SchoolId",
                principalTable: "schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_schools_SchoolId",
                table: "students",
                column: "SchoolId",
                principalTable: "schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
