using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using SmartSchool.API.Version1.DTO;
using System.Collections.Generic;
using AutoMapper;

namespace SmartSchool.API.Version1.Controllers
{
    /// <summary>
    /// Versão 1 do controlador de Alunos.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public StudentsController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável por retornar todos os meus alunos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var students = _repository.GetAllStudents(true);
            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(students));
        }

        /// <summary>
        /// Método responsável por retornar apenas um aluno por meio do ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _repository.GetStudentById(id, false);
            if (student == null) return BadRequest("Aluno não foi encontrado!");
            var studentDTO = _mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }

        /// <summary>
        /// Método responsável por inserir um novo aluno.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Método responsável por atualizar um aluno através do seu ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por atualizar um aluno através do seu ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por deletar um aluno através do seu ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
