﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartSchool.API.Data;

namespace SmartSchool.API.Migrations
{
    [DbContext(typeof(SmartContext))]
    partial class SmartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("SmartSchool.API.Models.SchoolSubject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("SchoolSubject");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Math",
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Physics",
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 3,
                            Name = "Portuguese",
                            TeacherId = 3
                        },
                        new
                        {
                            Id = 4,
                            Name = "English",
                            TeacherId = 4
                        },
                        new
                        {
                            Id = 5,
                            Name = "Biology",
                            TeacherId = 5
                        });
                });

            modelBuilder.Entity("SmartSchool.API.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Marta",
                            Phone = "933225555",
                            Surname = "Kent"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Paula",
                            Phone = "973354288",
                            Surname = "Isabela"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Laura",
                            Phone = "955668899",
                            Surname = "Antonia"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Luiza",
                            Phone = "9965656959",
                            Surname = "Maria"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Lucas",
                            Phone = "9565685415",
                            Surname = "Machado"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Pedro",
                            Phone = "9456454545",
                            Surname = "Alvares"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Paulo",
                            Phone = "998745192",
                            Surname = "José"
                        });
                });

            modelBuilder.Entity("SmartSchool.API.Models.StudentsSchoolSubjects", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SchoolSubjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "SchoolSubjectId");

                    b.HasIndex("SchoolSubjectId");

                    b.ToTable("StudentsSchoolSubjects");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            SchoolSubjectId = 2
                        },
                        new
                        {
                            StudentId = 1,
                            SchoolSubjectId = 4
                        },
                        new
                        {
                            StudentId = 1,
                            SchoolSubjectId = 5
                        },
                        new
                        {
                            StudentId = 2,
                            SchoolSubjectId = 1
                        },
                        new
                        {
                            StudentId = 2,
                            SchoolSubjectId = 2
                        },
                        new
                        {
                            StudentId = 2,
                            SchoolSubjectId = 5
                        },
                        new
                        {
                            StudentId = 3,
                            SchoolSubjectId = 1
                        },
                        new
                        {
                            StudentId = 3,
                            SchoolSubjectId = 2
                        },
                        new
                        {
                            StudentId = 3,
                            SchoolSubjectId = 3
                        },
                        new
                        {
                            StudentId = 4,
                            SchoolSubjectId = 1
                        },
                        new
                        {
                            StudentId = 4,
                            SchoolSubjectId = 4
                        },
                        new
                        {
                            StudentId = 4,
                            SchoolSubjectId = 5
                        },
                        new
                        {
                            StudentId = 5,
                            SchoolSubjectId = 4
                        },
                        new
                        {
                            StudentId = 5,
                            SchoolSubjectId = 5
                        },
                        new
                        {
                            StudentId = 6,
                            SchoolSubjectId = 1
                        },
                        new
                        {
                            StudentId = 6,
                            SchoolSubjectId = 2
                        },
                        new
                        {
                            StudentId = 6,
                            SchoolSubjectId = 3
                        },
                        new
                        {
                            StudentId = 6,
                            SchoolSubjectId = 4
                        },
                        new
                        {
                            StudentId = 7,
                            SchoolSubjectId = 1
                        },
                        new
                        {
                            StudentId = 7,
                            SchoolSubjectId = 2
                        },
                        new
                        {
                            StudentId = 7,
                            SchoolSubjectId = 3
                        },
                        new
                        {
                            StudentId = 7,
                            SchoolSubjectId = 4
                        },
                        new
                        {
                            StudentId = 7,
                            SchoolSubjectId = 5
                        });
                });

            modelBuilder.Entity("SmartSchool.API.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lauro"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Roberto"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ronaldo"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Rodrigo"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Alexandre"
                        });
                });

            modelBuilder.Entity("SmartSchool.API.Models.SchoolSubject", b =>
                {
                    b.HasOne("SmartSchool.API.Models.Teacher", "Teacher")
                        .WithMany("SchoolSubjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SmartSchool.API.Models.StudentsSchoolSubjects", b =>
                {
                    b.HasOne("SmartSchool.API.Models.SchoolSubject", "SchoolSubject")
                        .WithMany("StudentsSchoolSubjects")
                        .HasForeignKey("SchoolSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool.API.Models.Student", "Student")
                        .WithMany("StudentsSchoolSubjects")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
