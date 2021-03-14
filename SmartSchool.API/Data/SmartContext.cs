using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;

namespace SmartSchool.API.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<StudentSchoolSubject> StudentSchoolSubject { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<SchoolSubject> SchoolSubjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentSchoolSubject>()
                   .HasKey(SSS => new { SSS.StudentId, SSS.SchoolSubjectId });

            builder.Entity<StudentCourse>()
                   .HasKey(SC => new { SC.StudentId, SC.CourseId });

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                     new Teacher(1, 1, "Lauro", "Oliveira"),
                    new Teacher(2, 2, "Roberto", "Soares"),
                    new Teacher(3, 3, "Ronaldo", "Marconi"),
                    new Teacher(4, 4, "Rodrigo", "Carvalho"),
                    new Teacher(5, 5, "Alexandre", "Montanha"),
                });

            builder.Entity<Course>()
    .HasData(new List<Course>{
                    new Course(1, "Tecnologia da Informação"),
                    new Course(2, "Sistemas de Informação"),
                    new Course(3, "Ciência da Computação")
    });

            builder.Entity<SchoolSubject>()
                .HasData(new List<SchoolSubject>{
                    new SchoolSubject(1, "Matemática", 1, 1),
                    new SchoolSubject(2, "Matemática", 1, 3),
                    new SchoolSubject(3, "Física", 2, 3),
                    new SchoolSubject(4, "Português", 3, 1),
                    new SchoolSubject(5, "Inglês", 4, 1),
                    new SchoolSubject(6, "Inglês", 4, 2),
                    new SchoolSubject(7, "Inglês", 4, 3),
                    new SchoolSubject(8, "Programação", 5, 1),
                    new SchoolSubject(9, "Programação", 5, 2),
                    new SchoolSubject(10, "Programação", 5, 3)
                });

            builder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, 1, "Marta", "Kent", "33225555", DateTime.Parse("28/05/2005")),
                    new Student(2, 2, "Paula", "Isabela", "3354288", DateTime.Parse("28/05/2005")),
                    new Student(3, 3, "Laura", "Antonia", "55668899", DateTime.Parse("28/05/2005")),
                    new Student(4, 4, "Luiza", "Maria", "6565659", DateTime.Parse("28/05/2005")),
                    new Student(5, 5, "Lucas", "Machado", "565685415", DateTime.Parse("28/05/2005")),
                    new Student(6, 6, "Pedro", "Alvares", "456454545", DateTime.Parse("28/05/2005")),
                    new Student(7, 7, "Paulo", "José", "9874512", DateTime.Parse("28/05/2005"))
                });

            builder.Entity<StudentSchoolSubject>()
                .HasData(new List<StudentSchoolSubject>() {
                    new StudentSchoolSubject() {StudentId = 1, SchoolSubjectId = 2 },
                    new StudentSchoolSubject() {StudentId = 1, SchoolSubjectId = 4 },
                    new StudentSchoolSubject() {StudentId = 1, SchoolSubjectId = 5 },
                    new StudentSchoolSubject() {StudentId = 2, SchoolSubjectId = 1 },
                    new StudentSchoolSubject() {StudentId = 2, SchoolSubjectId = 2 },
                    new StudentSchoolSubject() {StudentId = 2, SchoolSubjectId = 5 },
                    new StudentSchoolSubject() {StudentId = 3, SchoolSubjectId = 1 },
                    new StudentSchoolSubject() {StudentId = 3, SchoolSubjectId = 2 },
                    new StudentSchoolSubject() {StudentId = 3, SchoolSubjectId = 3 },
                    new StudentSchoolSubject() {StudentId = 4, SchoolSubjectId = 1 },
                    new StudentSchoolSubject() {StudentId = 4, SchoolSubjectId = 4 },
                    new StudentSchoolSubject() {StudentId = 4, SchoolSubjectId = 5 },
                    new StudentSchoolSubject() {StudentId = 5, SchoolSubjectId = 4 },
                    new StudentSchoolSubject() {StudentId = 5, SchoolSubjectId = 5 },
                    new StudentSchoolSubject() {StudentId = 6, SchoolSubjectId = 1 },
                    new StudentSchoolSubject() {StudentId = 6, SchoolSubjectId = 2 },
                    new StudentSchoolSubject() {StudentId = 6, SchoolSubjectId = 3 },
                    new StudentSchoolSubject() {StudentId = 6, SchoolSubjectId = 4 },
                    new StudentSchoolSubject() {StudentId = 7, SchoolSubjectId = 1 },
                    new StudentSchoolSubject() {StudentId = 7, SchoolSubjectId = 2 },
                    new StudentSchoolSubject() {StudentId = 7, SchoolSubjectId = 3 },
                    new StudentSchoolSubject() {StudentId = 7, SchoolSubjectId = 4 },
                    new StudentSchoolSubject() {StudentId = 7, SchoolSubjectId = 5 }
                });
        }
    }
}
