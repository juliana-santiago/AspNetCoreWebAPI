using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class StudentsSchoolSubjects
    {
        public StudentsSchoolSubjects(){ } 
        public StudentsSchoolSubjects(int alunoId,int disciplinaId)
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaId;
        }

        public int AlunoId { get; set; }
        public Student Aluno { get; set; }
        public int DisciplinaId { get; set; }
        public SchoolSubjects Disciplina { get; set; }
    }
}
