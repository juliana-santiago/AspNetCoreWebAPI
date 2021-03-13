using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class StudentsSchoolSubjects
    {
        public StudentsSchoolSubjects(){ } 
        public StudentsSchoolSubjects(int studentId,int schoolSubjectId)
        {
            this.StudentId = studentId;
            this.SchoolSubjectId = schoolSubjectId;
        }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SchoolSubjectId { get; set; }
        public SchoolSubject SchoolSubject { get; set; }
    }
}
