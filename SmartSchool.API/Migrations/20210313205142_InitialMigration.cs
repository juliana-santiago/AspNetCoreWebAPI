using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacheres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacheres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolSubject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolSubject_Teacheres_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teacheres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsSchoolSubjects",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    SchoolSubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsSchoolSubjects", x => new { x.StudentId, x.SchoolSubjectId });
                    table.ForeignKey(
                        name: "FK_StudentsSchoolSubjects_SchoolSubject_SchoolSubjectId",
                        column: x => x.SchoolSubjectId,
                        principalTable: "SchoolSubject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsSchoolSubjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 1, "Marta", "933225555", "Kent" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 2, "Paula", "973354288", "Isabela" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 3, "Laura", "955668899", "Antonia" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 4, "Luiza", "9965656959", "Maria" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 5, "Lucas", "9565685415", "Machado" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 6, "Pedro", "9456454545", "Alvares" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Name", "Phone", "Surname" },
                values: new object[] { 7, "Paulo", "998745192", "José" });

            migrationBuilder.InsertData(
                table: "Teacheres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Lauro" });

            migrationBuilder.InsertData(
                table: "Teacheres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Roberto" });

            migrationBuilder.InsertData(
                table: "Teacheres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Ronaldo" });

            migrationBuilder.InsertData(
                table: "Teacheres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Rodrigo" });

            migrationBuilder.InsertData(
                table: "Teacheres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Alexandre" });

            migrationBuilder.InsertData(
                table: "SchoolSubject",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 1, "Math", 1 });

            migrationBuilder.InsertData(
                table: "SchoolSubject",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 2, "Physics", 2 });

            migrationBuilder.InsertData(
                table: "SchoolSubject",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 3, "Portuguese", 3 });

            migrationBuilder.InsertData(
                table: "SchoolSubject",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 4, "English", 4 });

            migrationBuilder.InsertData(
                table: "SchoolSubject",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 5, "Biology", 5 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 4, 5 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 7, 4 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 5, 4 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 7, 3 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 5, 5 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 6, 3 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 7, 2 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 6, 2 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 7, 1 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 6, 1 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "StudentsSchoolSubjects",
                columns: new[] { "StudentId", "SchoolSubjectId" },
                values: new object[] { 7, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolSubject_TeacherId",
                table: "SchoolSubject",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSchoolSubjects_SchoolSubjectId",
                table: "StudentsSchoolSubjects",
                column: "SchoolSubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsSchoolSubjects");

            migrationBuilder.DropTable(
                name: "SchoolSubject");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teacheres");
        }
    }
}
