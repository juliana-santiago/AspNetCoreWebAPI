using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class Teacher
    {
        public Teacher(){ }

        public Teacher(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SchoolSubject> SchoolSubjects { get; set; }
    }
}
