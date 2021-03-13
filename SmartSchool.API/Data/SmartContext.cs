using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;
using System.Collections.Generic;

namespace SmartSchool.API.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teacheres { get; set; }
        public DbSet<SchoolSubject> SchoolSubject { get; set; }
        public DbSet<StudentsSchoolSubjects> StudentsSchoolSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentsSchoolSubjects>()
                .HasKey(AD => new { AD.StudentId, AD.SchoolSubjectId });

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher(1, "Lauro"),
                    new Teacher(2, "Roberto"),
                    new Teacher(3, "Ronaldo"),
                    new Teacher(4, "Rodrigo"),
                    new Teacher(5, "Alexandre"),
                });

            builder.Entity<SchoolSubject>()
                .HasData(new List<SchoolSubject>{
                    new SchoolSubject(1, "Math", 1),
                    new SchoolSubject(2, "Physics", 2),
                    new SchoolSubject(3, "Portuguese", 3),
                    new SchoolSubject(4, "English", 4),
                    new SchoolSubject(5, "Biology", 5)
                });

            builder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, "Marta", "Kent", "933225555"),
                    new Student(2, "Paula", "Isabela", "973354288"),
                    new Student(3, "Laura", "Antonia", "955668899"),
                    new Student(4, "Luiza", "Maria", "9965656959"),
                    new Student(5, "Lucas", "Machado", "9565685415"),
                    new Student(6, "Pedro", "Alvares", "9456454545"),
                    new Student(7, "Paulo", "José", "998745192")
                });

            builder.Entity<StudentsSchoolSubjects>()
                .HasData(new List<StudentsSchoolSubjects>() {
                    new StudentsSchoolSubjects() {StudentId = 1, SchoolSubjectId = 2 },
                    new StudentsSchoolSubjects() {StudentId = 1, SchoolSubjectId = 4 },
                    new StudentsSchoolSubjects() {StudentId = 1, SchoolSubjectId = 5 },
                    new StudentsSchoolSubjects() {StudentId = 2, SchoolSubjectId = 1 },
                    new StudentsSchoolSubjects() {StudentId = 2, SchoolSubjectId = 2 },
                    new StudentsSchoolSubjects() {StudentId = 2, SchoolSubjectId = 5 },
                    new StudentsSchoolSubjects() {StudentId = 3, SchoolSubjectId = 1 },
                    new StudentsSchoolSubjects() {StudentId = 3, SchoolSubjectId = 2 },
                    new StudentsSchoolSubjects() {StudentId = 3, SchoolSubjectId = 3 },
                    new StudentsSchoolSubjects() {StudentId = 4, SchoolSubjectId = 1 },
                    new StudentsSchoolSubjects() {StudentId = 4, SchoolSubjectId = 4 },
                    new StudentsSchoolSubjects() {StudentId = 4, SchoolSubjectId = 5 },
                    new StudentsSchoolSubjects() {StudentId = 5, SchoolSubjectId = 4 },
                    new StudentsSchoolSubjects() {StudentId = 5, SchoolSubjectId = 5 },
                    new StudentsSchoolSubjects() {StudentId = 6, SchoolSubjectId = 1 },
                    new StudentsSchoolSubjects() {StudentId = 6, SchoolSubjectId = 2 },
                    new StudentsSchoolSubjects() {StudentId = 6, SchoolSubjectId = 3 },
                    new StudentsSchoolSubjects() {StudentId = 6, SchoolSubjectId = 4 },
                    new StudentsSchoolSubjects() {StudentId = 7, SchoolSubjectId = 1 },
                    new StudentsSchoolSubjects() {StudentId = 7, SchoolSubjectId = 2 },
                    new StudentsSchoolSubjects() {StudentId = 7, SchoolSubjectId = 3 },
                    new StudentsSchoolSubjects() {StudentId = 7, SchoolSubjectId = 4 },
                    new StudentsSchoolSubjects() {StudentId = 7, SchoolSubjectId = 5 }
                });
        }
    }
}
