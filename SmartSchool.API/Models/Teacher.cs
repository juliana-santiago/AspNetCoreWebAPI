using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Models
{
    public class Teacher
    {
        public Teacher(){ }

        public Teacher(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<SchoolSubjects> Disciplinas { get; set; }
    }
}
