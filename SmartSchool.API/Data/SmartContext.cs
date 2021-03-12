using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Data
{
    public class SmartContext : DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) { }

        public DbSet<Student> Alunos { get; set; }
        public DbSet<Teacher> Professsores { get; set; }
        public DbSet<SchoolSubjects> Disciplinas { get; set; }
        public DbSet<StudentsSchoolSubjects> AlunosDisciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentsSchoolSubjects>()
                .HasKey(AD => new { AD.AlunoId, AD.DisciplinaId });

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher(1, "Lauro"),
                    new Teacher(2, "Roberto"),
                    new Teacher(3, "Ronaldo"),
                    new Teacher(4, "Rodrigo"),
                    new Teacher(5, "Alexandre"),
                });

            builder.Entity<SchoolSubjects>()
                .HasData(new List<SchoolSubjects>{
                    new SchoolSubjects(1, "Matemática", 1),
                    new SchoolSubjects(2, "Física", 2),
                    new SchoolSubjects(3, "Português", 3),
                    new SchoolSubjects(4, "Inglês", 4),
                    new SchoolSubjects(5, "Programação", 5)
                });

            builder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, "Marta", "Kent", "33225555"),
                    new Student(2, "Paula", "Isabela", "3354288"),
                    new Student(3, "Laura", "Antonia", "55668899"),
                    new Student(4, "Luiza", "Maria", "6565659"),
                    new Student(5, "Lucas", "Machado", "565685415"),
                    new Student(6, "Pedro", "Alvares", "456454545"),
                    new Student(7, "Paulo", "José", "9874512")
                });

            builder.Entity<StudentsSchoolSubjects>()
                .HasData(new List<StudentsSchoolSubjects>() {
                    new StudentsSchoolSubjects() {AlunoId = 1, DisciplinaId = 2 },
                    new StudentsSchoolSubjects() {AlunoId = 1, DisciplinaId = 4 },
                    new StudentsSchoolSubjects() {AlunoId = 1, DisciplinaId = 5 },
                    new StudentsSchoolSubjects() {AlunoId = 2, DisciplinaId = 1 },
                    new StudentsSchoolSubjects() {AlunoId = 2, DisciplinaId = 2 },
                    new StudentsSchoolSubjects() {AlunoId = 2, DisciplinaId = 5 },
                    new StudentsSchoolSubjects() {AlunoId = 3, DisciplinaId = 1 },
                    new StudentsSchoolSubjects() {AlunoId = 3, DisciplinaId = 2 },
                    new StudentsSchoolSubjects() {AlunoId = 3, DisciplinaId = 3 },
                    new StudentsSchoolSubjects() {AlunoId = 4, DisciplinaId = 1 },
                    new StudentsSchoolSubjects() {AlunoId = 4, DisciplinaId = 4 },
                    new StudentsSchoolSubjects() {AlunoId = 4, DisciplinaId = 5 },
                    new StudentsSchoolSubjects() {AlunoId = 5, DisciplinaId = 4 },
                    new StudentsSchoolSubjects() {AlunoId = 5, DisciplinaId = 5 },
                    new StudentsSchoolSubjects() {AlunoId = 6, DisciplinaId = 1 },
                    new StudentsSchoolSubjects() {AlunoId = 6, DisciplinaId = 2 },
                    new StudentsSchoolSubjects() {AlunoId = 6, DisciplinaId = 3 },
                    new StudentsSchoolSubjects() {AlunoId = 6, DisciplinaId = 4 },
                    new StudentsSchoolSubjects() {AlunoId = 7, DisciplinaId = 1 },
                    new StudentsSchoolSubjects() {AlunoId = 7, DisciplinaId = 2 },
                    new StudentsSchoolSubjects() {AlunoId = 7, DisciplinaId = 3 },
                    new StudentsSchoolSubjects() {AlunoId = 7, DisciplinaId = 4 },
                    new StudentsSchoolSubjects() {AlunoId = 7, DisciplinaId = 5 }
                });
        }
    }
}
