using System;
using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Course
    {
        public Course() { }
        public Course(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SchoolSubject> SchoolSubjects { get; set; }
    }
}
