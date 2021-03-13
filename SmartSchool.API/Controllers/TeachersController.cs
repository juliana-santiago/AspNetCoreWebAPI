using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly SmartContext _context;

        public TeachersController(SmartContext context)
        {
            _context = context;
        }

        // api/teachers -> todos os professores
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Teachers);
        }

        // api/teachers/byId/{id} -> filtra por Id 
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null) return BadRequest("Professor não foi encontrado!");

            return Ok(teacher);
        }

        // api/teachers/byName/{name}&{id} -> filtra por Nome
        [HttpGet("byName/{name}&{id}")]
        public IActionResult GetByNome(string name, int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Name.Contains(name) && t.Id == id);
            if (teacher == null) return BadRequest("Professor não foi encontrado!");

            return Ok(teacher);
        }

        // api/teachers -> Insere um novo registro
        [HttpPost]
        public IActionResult Post(Teacher teacher)
        {
            _context.Add(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        // api/teachers -> Atualiza um registro por Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Teacher teacher)
        {
            var teach = _context.Teachers.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if (teach == null) return BadRequest("Professor nao encontrado!");
            _context.Update(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }


        // api/teachers -> Atualiza uma informação especifica do registro por Id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Teacher teacher)
        {
            var teach = _context.Teachers.AsNoTracking().FirstOrDefault(t => t.Id == id);
            if (teach == null) return BadRequest("Professor nao encontrado!");
            _context.Update(teacher);
            _context.SaveChanges();
            return Ok(teacher);
        }

        // api/teachers -> Deleta um registro por Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null) return BadRequest("Professor nao encontrado!");
            _context.Remove(teacher);
            _context.SaveChanges();
            return Ok($"Registro {id} deletado com sucesso!");
        }
    }
}
