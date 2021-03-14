using System;
using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Student
    {
        public Student() {}
        public Student(int id, int registration, string name, string surname, string phone, DateTime birthDate)
        {
            this.Id = id;
            this.Registration = registration;
            this.Name = name;
            this.Surname = surname;
            this.Phone = phone;
            this.BirthDate = birthDate;
        }
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? FinalDate { get; set; } = null;
        public bool Active { get; set; } = true;
        public IEnumerable<StudentSchoolSubject> StudentsSchoolSubjects { get; set; }
    }
}
