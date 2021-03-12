using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Collections.Generic;
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

        // api/alunos -> todos os alunos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        // api/alunos/byId/{id} -> filtra por Id 
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não foi encontrado!");

            return Ok(aluno);
        }

        // api/alunos/byNome/{nome}&{sobrenome} -> filtra por Nome
        [HttpGet("byNome/{nome}&{sobrenome}")]
        public IActionResult GetByNome(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("Aluno não foi encontrado!");

            return Ok(aluno);
        }

        // api/alunos -> Insere um novo registro
        [HttpPost]
        public IActionResult Post(Student aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // api/alunos -> Atualiza um registro por Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student aluno)
        {
            var alu = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno nao encontrado!");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }


        // api/alunos -> Atualiza uma informação especifica do registro por Id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student aluno)
        {
            var alu = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno nao encontrado!");
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // api/alunos -> Deleta um registro por Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno nao encontrado!");
            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok($"Registro {id} deletado com sucesso!");
        }
    }
}
