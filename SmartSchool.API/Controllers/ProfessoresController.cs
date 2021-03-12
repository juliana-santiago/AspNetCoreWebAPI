using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoresController : ControllerBase
    {
        public ProfessoresController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Professores: Caio, Jõao, Leticia, Felipe");
        }
    }
}
