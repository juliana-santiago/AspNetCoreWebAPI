using System;

namespace SmartSchool.API.Models
{
    public class StudentSchoolSubject
    {
        public StudentSchoolSubject(){ } 
        public StudentSchoolSubject(int studentId,int schoolSubjectId)
        {
            this.StudentId = studentId;
            this.SchoolSubjectId = schoolSubjectId;
        }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? FinalDate { get; set; }
        public int? Grades { get; set; } = null;
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SchoolSubjectId { get; set; }
        public SchoolSubject SchoolSubject { get; set; }
    }
}
