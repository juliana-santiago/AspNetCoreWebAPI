using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Student
    {
        public Student() {}
        public Student(int id, string name, string surname, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Phone = phone;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public IEnumerable<StudentsSchoolSubjects> StudentsSchoolSubjects { get; set; }
    }
}
