using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using SmartSchool.API.DTO;
using System.Collections.Generic;
using AutoMapper;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public StudentsController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // api/students -> todos os estudantes
        [HttpGet]
        public IActionResult Get()
        {
            var students = _repository.GetAllStudents(true);
            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(students));
        }

        // api/students/{id} -> filtra por Id 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repository.GetStudentById(id, false);
            if (student == null) return BadRequest("Aluno não foi encontrado!");
            var studentDTO = _mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }

        // api/students -> Insere um novo registro
        [HttpPost]
        public IActionResult Post(RegisterStudentDTO model)
        {
            var student = _mapper.Map<Student>(model);

            _repository.Add(student);
            if (_repository.SaveChanges() == true)
            { 
                return Created($"/api/students/{model.Id}", _mapper.Map<StudentDTO>(student));
            };
            return BadRequest("Aluno não cadastrado!");
        }

        // api/students -> Atualiza um registro por Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, RegisterStudentDTO model)
        {
            var student = _repository.GetStudentById(id, false);
            if (student == null) return BadRequest("Aluno nao encontrado!");

            _mapper.Map(model, student);

            _repository.Update(student);
            if (_repository.SaveChanges() == true)
            {
                return Created($"/api/students/{model.Id}", _mapper.Map<StudentDTO>(student)); 
            };
            return BadRequest("Aluno não atualizado!");
        }

        // api/students -> Atualiza uma informação especifica do registro por Id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, RegisterStudentDTO model)
        {
            var student = _repository.GetStudentById(id, false);
            if (student == null) return BadRequest("Aluno nao encontrado!");

            _mapper.Map(model, student);

            _repository.Update(student);
            if (_repository.SaveChanges() == true)
            {
                return Created($"/api/students/{model.Id}", _mapper.Map<StudentDTO>(student));
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
