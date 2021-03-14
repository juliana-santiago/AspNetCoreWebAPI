using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.DTO
{
    public class RegisterStudentDTO
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? FinalDate { get; set; } = null;
        public bool Active { get; set; } = true;
    }
}
