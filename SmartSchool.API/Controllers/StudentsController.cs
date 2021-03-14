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
        private readonly IRepository _repository;

        public StudentsController(IRepository repository)
        {
            _repository = repository;
        }

        // api/students -> todos os estudantes
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAllStudents(true);
            return Ok(result);
        }

        // api/students/{id} -> filtra por Id 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repository.GetStudentById(id, false);
            if (student == null) return BadRequest("Aluno não foi encontrado!");

            return Ok(student);
        }

        // api/students -> Insere um novo registro
        [HttpPost]
        public IActionResult Post(Student student)
        {
            _repository.Add(student);
            if (_repository.SaveChanges() == true)
            { 
                return Ok(student);
            };
            return BadRequest("Aluno não cadastrado!");
        }

        // api/students -> Atualiza um registro por Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            var stud = _repository.GetStudentById(id, false);
            if (stud == null) return BadRequest("Aluno nao encontrado!");
            
            _repository.Update(student);
            if (_repository.SaveChanges() == true)
            {
                return Ok(student);
            };
            return BadRequest("Aluno não atualizado!");
        }

        // api/students -> Atualiza uma informação especifica do registro por Id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Student student)
        {
            var stud = _repository.GetStudentById(id, false);
            if (stud == null) return BadRequest("Aluno nao encontrado!");

            _repository.Update(student);
            if (_repository.SaveChanges() == true)
            {
                return Ok(student);
            };
            return BadRequest("Aluno não atualizado!");
        }

        // api/students -> Deleta um registro por Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _repository.GetStudentById(id, false);
            if (student == null) return BadRequest("Aluno nao encontrado!");
            
            _repository.Delete(student);
            if (_repository.SaveChanges() == true)
            {
                return Ok("Aluno deletado!");
            };
            return BadRequest("Aluno não deletado!");
        }
    }
}
