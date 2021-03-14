using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.DTO
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime StartDate { get; set; }
        public bool Active { get; set; } = true;
    }
}
