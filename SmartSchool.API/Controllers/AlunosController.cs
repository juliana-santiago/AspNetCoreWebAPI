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


        // api/alunos -> todos os alunos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // api/alunos/byId/{id} -> filtra por Id 
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não foi encontrado!");

            return Ok(aluno);
        }

        // api/alunos/byNome/{nome}&{sobrenome} -> filtra por Nome
        [HttpGet("byNome/{nome}&{sobrenome}")]
        public IActionResult GetByNome(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("Aluno não foi encontrado!");

            return Ok(aluno);
        }

        // api/alunos -> Insere um novo registro
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        // api/alunos -> Atualiza um registro por Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }


        // api/alunos -> Atualiza uma informação especifica do registro por Id
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // api/alunos -> Deleta um registro por Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Registro {id} deletado com sucesso!");
        }
    }
}
