using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class SchoolSubject
    {
        public SchoolSubject(){}
        public SchoolSubject(int id, string name, int teacherId, int courseId)
        {
            this.Id = id;
            this.Name = name;
            this.TeacherId = teacherId;
            this.CourseId = courseId;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Workload { get; set; }
        public int? PrerequisiteId { get; set; } = null;
        public SchoolSubject Prerequisite { get; set; } 
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public IEnumerable<StudentSchoolSubject> StudentsSchoolSubjects { get; set; }
    }
}
