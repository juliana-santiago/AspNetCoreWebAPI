using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class SchoolSubjects
    {
        public SchoolSubjects(){}

        public SchoolSubjects(int id, string nome, int professorId)
        {
            this.Id = id;
            this.Nome = nome;
            this.ProfessorId = professorId;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int ProfessorId { get; set; }
        public Teacher professor { get; set; }
        public IEnumerable<StudentsSchoolSubjects> AlunosDisciplinas { get; set; }
    }
}
