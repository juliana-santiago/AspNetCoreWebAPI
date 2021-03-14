using System;

namespace SmartSchool.API.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public DateTime StartDate { get; set; }
        public bool Active { get; set; }
    }
}
