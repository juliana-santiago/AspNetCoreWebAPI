using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class SchoolSubject
    {
        public SchoolSubject(){}

        public SchoolSubject(int id, string name, int teacherId)
        {
            this.Id = id;
            this.Name = name;
            this.TeacherId = teacherId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public IEnumerable<StudentsSchoolSubjects> StudentsSchoolSubjects { get; set; }
    }
}
