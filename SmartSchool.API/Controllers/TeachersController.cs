using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.DTO;
using SmartSchool.API.Models;
using System.Collections.Generic;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public TeachersController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // api/teachers -> todos os professores
        [HttpGet]
        public IActionResult Get()
        {
            var teachers = _repository.GetAllTeachers(true);
            return Ok(_mapper.Map<IEnumerable<TeacherDTO>>(teachers));
        }

        // api/teachers/{id} -> filtra por Id 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _repository.GetTeacherById(id, false);
            if (teacher == null) return BadRequest("Professor não foi encontrado!");

            var teacherDTO = _mapper.Map<TeacherDTO>(teacher);
            return Ok(teacherDTO);
        }

        // api/teachers -> Insere um novo registro
        [HttpPost]
        public IActionResult Post(RegisterTeacherDTO model)
        {
            var teacher = _mapper.Map<Teacher>(model);

            _repository.Add(teacher);
            if (_repository.SaveChanges() == true)
            {
                return Created($"/api/teachers/{model.Id}", _mapper.Map<TeacherDTO>(teacher));
            };
            return BadRequest("Professor não cadastrado!");
        }

        // api/teachers -> Atualiza um registro por Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, RegisterTeacherDTO model)
        {
            var teacher = _repository.GetTeacherById(id, false);
            if (teacher == null) return BadRequest("Professor nao encontrado!");

            _mapper.Map(model, teacher);

            _repository.Update(teacher);
            if (_repository.SaveChanges() == true)
            {
                return Created($"/api/students/{model.Id}", _mapper.Map<TeacherDTO>(teacher));
            };
            return BadRequest("Professor não atualizado!");
        }

        // api/teachers -> Atualiza uma informação especifica do registro por Id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, RegisterTeacherDTO model)
        {
            var teacher = _repository.GetTeacherById(id, false);
            if (teacher == null) return BadRequest("Professor nao encontrado!");
            
            _mapper.Map(model, teacher);

            _repository.Update(teacher);
            if (_repository.SaveChanges() == true)
            {
                return Created($"/api/students/{model.Id}", _mapper.Map<TeacherDTO>(teacher));
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
