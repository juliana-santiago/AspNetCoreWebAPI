using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Silva",
                Telefone = "984875268"
            },
            new Aluno()
            {
                Id = 3,
                Nome = "Marta",
                Sobrenome = "Dias",
                Telefone = "984348458"
            },
            new Aluno()
            {
                Id = 3,
                Nome = "Pedro",
                Sobrenome = "Steves",
                Telefone = "978742813"
            }
        };

        public AlunosController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não foi encontrado!");

            return Ok(aluno);
        }
    }
}
