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
        private readonly IRepository _repository;

        public TeachersController(IRepository repository)
        {
            _repository = repository;
        }

        // api/teachers -> todos os professores
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.GetAllTeachers(true);
            return Ok(result);
        }

        // api/teachers/{id} -> filtra por Id 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _repository.GetTeacherById(id, false);
            if (teacher == null) return BadRequest("Professor não foi encontrado!");

            return Ok(teacher);
        }

        // api/teachers -> Insere um novo registro
        [HttpPost]
        public IActionResult Post(Teacher teacher)
        {
            _repository.Add(teacher);
            if (_repository.SaveChanges() == true)
            {
                return Ok(teacher);
            };
            return BadRequest("Professor não cadastrado!");
        }

        // api/teachers -> Atualiza um registro por Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Teacher teacher)
        {
            var teach = _repository.GetTeacherById(id, false);
            if (teach == null) return BadRequest("Professor nao encontrado!");


            _repository.Update(teacher);
            if (_repository.SaveChanges() == true)
            {
                return Ok(teacher);
            };
            return BadRequest("Professor não atualizado!");
        }

        // api/teachers -> Atualiza uma informação especifica do registro por Id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Teacher teacher)
        {
            var teach = _repository.GetTeacherById(id, false);
            if (teach == null) return BadRequest("Professor nao encontrado!");

            _repository.Update(teacher);
            if (_repository.SaveChanges() == true)
            {
                return Ok(teacher);
            };
            return BadRequest("Professor não atualizado!");
        }

        // api/teachers -> Deleta um registro por Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = _repository.GetTeacherById(id, false);
            if (teacher == null) return BadRequest("Professor nao encontrado!");

            _repository.Delete(teacher);
            if (_repository.SaveChanges() == true)
            {
                return Ok("Professor deletado!");
            };
            return BadRequest("Professor não deletado!");
        }
    }
}
