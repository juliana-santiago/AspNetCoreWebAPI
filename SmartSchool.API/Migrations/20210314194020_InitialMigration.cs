using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registration = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registration = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinalDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinalDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Workload = table.Column<int>(nullable: false),
                    PrerequisiteId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolSubjects_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolSubjects_SchoolSubjects_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "SchoolSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SchoolSubjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSchoolSubject",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    SchoolSubjectId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinalDate = table.Column<DateTime>(nullable: true),
                    Grades = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSchoolSubject", x => new { x.StudentId, x.SchoolSubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSchoolSubject_SchoolSubjects_SchoolSubjectId",
                        column: x => x.SchoolSubjectId,
                        principalTable: "SchoolSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSchoolSubject_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Sistemas de Informação" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "BirthDate", "FinalDate", "Name", "Phone", "Registration", "StartDate", "Surname" },
                values: new object[] { 1, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marta", "33225555", 1, new DateTime(2021, 3, 14, 16, 40, 20, 48, DateTimeKind.Local).AddTicks(4612), "Kent" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "BirthDate", "FinalDate", "Name", "Phone", "Registration", "StartDate", "Surname" },
                values: new object[] { 2, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paula", "3354288", 2, new DateTime(2021, 3, 14, 16, 40, 20, 48, DateTimeKind.Local).AddTicks(7621), "Isabela" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "BirthDate", "FinalDate", "Name", "Phone", "Registration", "StartDate", "Surname" },
                values: new object[] { 3, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Laura", "55668899", 3, new DateTime(2021, 3, 14, 16, 40, 20, 48, DateTimeKind.Local).AddTicks(7683), "Antonia" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "BirthDate", "FinalDate", "Name", "Phone", "Registration", "StartDate", "Surname" },
                values: new object[] { 4, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Luiza", "6565659", 4, new DateTime(2021, 3, 14, 16, 40, 20, 48, DateTimeKind.Local).AddTicks(7692), "Maria" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "BirthDate", "FinalDate", "Name", "Phone", "Registration", "StartDate", "Surname" },
                values: new object[] { 5, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lucas", "565685415", 5, new DateTime(2021, 3, 14, 16, 40, 20, 48, DateTimeKind.Local).AddTicks(7700), "Machado" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "BirthDate", "FinalDate", "Name", "Phone", "Registration", "StartDate", "Surname" },
                values: new object[] { 6, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Pedro", "456454545", 6, new DateTime(2021, 3, 14, 16, 40, 20, 48, DateTimeKind.Local).AddTicks(7711), "Alvares" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "BirthDate", "FinalDate", "Name", "Phone", "Registration", "StartDate", "Surname" },
                values: new object[] { 7, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Paulo", "9874512", 7, new DateTime(2021, 3, 14, 16, 40, 20, 48, DateTimeKind.Local).AddTicks(7718), "José" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "FinalDate", "Name", "Phone", "Registration", "StartDate", "Surname" },
                values: new object[] { 1, true, null, "Lauro", null, 1, new DateTime(2021, 3, 14, 16, 40, 20, 43, DateTimeKind.Local).AddTicks(4839), "Oliveira" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "FinalDate", "Name", "Phone", "Registration", "StartDate", "Surname" },
                values: new object[] { 2, true, null, "Roberto", null, 2, new DateTime(2021, 3, 14, 16, 40, 20, 44, DateTimeKind.Local).AddTicks(6090), "Soares" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "FinalDate", "Name", "Phone", "Registration", "StartDate", "Surname" },
                values: new object[] { 3, true, null, "Ronaldo", null, 3, new DateTime(2021, 3, 14, 16, 40, 20, 44, DateTimeKind.Local).AddTicks(6138), "Marconi" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "FinalDate", "Name", "Phone", "Registration", "StartDate", "Surname" },
                values: new object[] { 4, true, null, "Rodrigo", null, 4, new DateTime(2021, 3, 14, 16, 40, 20, 44, DateTimeKind.Local).AddTicks(6141), "Carvalho" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "FinalDate", "Name", "Phone", "Registration", "StartDate", "Surname" },
                values: new object[] { 5, true, null, "Alexandre", null, 5, new DateTime(2021, 3, 14, 16, 40, 20, 44, DateTimeKind.Local).AddTicks(6143), "Montanha" });

            migrationBuilder.InsertData(
                table: "SchoolSubjects",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 1, 1, "Matemática", null, 1, 0 });

            migrationBuilder.InsertData(
                table: "SchoolSubjects",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 2, 3, "Matemática", null, 1, 0 });

            migrationBuilder.InsertData(
                table: "SchoolSubjects",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 3, 3, "Física", null, 2, 0 });

            migrationBuilder.InsertData(
                table: "SchoolSubjects",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 4, 1, "Português", null, 3, 0 });

            migrationBuilder.InsertData(
                table: "SchoolSubjects",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 5, 1, "Inglês", null, 4, 0 });

            migrationBuilder.InsertData(
                table: "SchoolSubjects",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 6, 2, "Inglês", null, 4, 0 });

            migrationBuilder.InsertData(
                table: "SchoolSubjects",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 7, 3, "Inglês", null, 4, 0 });

            migrationBuilder.InsertData(
                table: "SchoolSubjects",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 8, 1, "Programação", null, 5, 0 });

            migrationBuilder.InsertData(
                table: "SchoolSubjects",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 9, 2, "Programação", null, 5, 0 });

            migrationBuilder.InsertData(
                table: "SchoolSubjects",
                columns: new[] { "Id", "CourseId", "Name", "PrerequisiteId", "TeacherId", "Workload" },
                values: new object[] { 10, 3, "Programação", null, 5, 0 });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 2, 1, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(311) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 4, 5, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(328) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 2, 5, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(317) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 1, 5, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(309) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 7, 4, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(346) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 6, 4, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(340) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 5, 4, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(330) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 4, 4, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(327) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 1, 4, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(276) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 7, 3, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(345) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 5, 5, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(332) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 6, 3, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(337) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 7, 2, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(343) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 6, 2, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(335) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 3, 2, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(321) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 2, 2, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(313) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 1, 2, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 48, DateTimeKind.Local).AddTicks(9293) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 7, 1, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(341) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 6, 1, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(333) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 4, 1, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(325) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 3, 1, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(319) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 3, 3, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(322) });

            migrationBuilder.InsertData(
                table: "StudentSchoolSubject",
                columns: new[] { "StudentId", "SchoolSubjectId", "FinalDate", "Grades", "StartDate" },
                values: new object[] { 7, 5, null, null, new DateTime(2021, 3, 14, 16, 40, 20, 49, DateTimeKind.Local).AddTicks(348) });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolSubjects_CourseId",
                table: "SchoolSubjects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolSubjects_PrerequisiteId",
                table: "SchoolSubjects",
                column: "PrerequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolSubjects_TeacherId",
                table: "SchoolSubjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSchoolSubject_SchoolSubjectId",
                table: "StudentSchoolSubject",
                column: "SchoolSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_CourseId",
                table: "StudentsCourses",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSchoolSubject");

            migrationBuilder.DropTable(
                name: "StudentsCourses");

            migrationBuilder.DropTable(
                name: "SchoolSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
