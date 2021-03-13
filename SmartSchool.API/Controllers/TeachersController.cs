using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        public TeachersController()
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Professores: Caio, Jõao, Leticia, Felipe");
        }
    }
}
