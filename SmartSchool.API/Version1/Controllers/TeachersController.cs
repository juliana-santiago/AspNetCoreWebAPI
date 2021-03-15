using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Data;
using SmartSchool.API.Version1.DTO;
using SmartSchool.API.Models;
using System.Collections.Generic;

namespace SmartSchool.API.Version1.Controllers
{
    /// <summary>
    /// Versão 1 do controlador de Professores.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public TeachersController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável por retornar todos os meus professor.
        /// </summary>
        /// <returns></returns>
        // api/teachers -> todos os professores
        [HttpGet]
        public IActionResult Get()
        {
            var teachers = _repository.GetAllTeachers(true);
            return Ok(_mapper.Map<IEnumerable<TeacherDTO>>(teachers));
        }

        /// <summary>
        /// Método responsável por retornar apenas um professor por meio do ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _repository.GetTeacherById(id, false);
            if (teacher == null) return BadRequest("Professor não foi encontrado!");

            var teacherDTO = _mapper.Map<TeacherDTO>(teacher);
            return Ok(teacherDTO);
        }

        /// <summary>
        /// Método responsável por inserir um novo professor.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por atualizar um professor através do seu ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por atualizar um professor através do seu ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método responsável por deletar um professor através do seu ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
