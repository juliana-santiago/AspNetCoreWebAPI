using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly SmartContext _context;

        public StudentsController(SmartContext context)
        {
            _context = context;
        }

        // api/students -> todos os estudantes
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Students);
        }

        // api/students/byId/{id} -> filtra por Id 
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var student = _context.Students.FirstOrDefault(a => a.Id == id);
            if (student == null) return BadRequest("Aluno não foi encontrado!");

            return Ok(student);
        }

        // api/students/byName/{name}&{surname} -> filtra por Nome
        [HttpGet("byName/{name}&{surname}")]
        public IActionResult GetByNome(string name, string surname)
        {
            var student = _context.Students.FirstOrDefault(a => a.Name.Contains(name) && a.Surname.Contains(surname));
            if (student == null) return BadRequest("Aluno não foi encontrado!");

            return Ok(student);
        }

        // api/students -> Insere um novo registro
        [HttpPost]
        public IActionResult Post(Student student)
        {
            _context.Add(student);
            _context.SaveChanges();
            return Ok(student);
        }

        // api/students -> Atualiza um registro por Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            var alu = _context.Students.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno nao encontrado!");
            _context.Update(student);
            _context.SaveChanges();
            return Ok(student);
        }

        // api/students -> Atualiza uma informação especifica do registro por Id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student student)
        {
            var alu = _context.Students.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno nao encontrado!");
            _context.Update(student);
            _context.SaveChanges();
            return Ok(student);
        }

        // api/students -> Deleta um registro por Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(a => a.Id == id);
            if (student == null) return BadRequest("Aluno nao encontrado!");
            _context.Remove(student);
            _context.SaveChanges();
            return Ok($"Registro {id} deletado com sucesso!");
        }
    }
}
