using Microsoft.AspNetCore.Mvc;
using services.Dto;
using services.Usuario;

namespace roulettegame_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UsuarioController(IUsuario usuarioService) : ControllerBase
    {
        [HttpPost("AddNewUserOrAddAmount")]
        public async Task<IActionResult> AddNewUserOrAddAmount([FromBody] UserDto user)
        {
            var response = await usuarioService.AddUser(user);
            return Ok(response);
        }

        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddNewUser([FromBody] UserDto user)
        {
            var response = await usuarioService.AddUserUsingSPA(user);
            return Ok(response);
        }

        [HttpGet("GetUserByName/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var response = await usuarioService.GetUserByName(name);
            return Ok(response);
        }

    }
}
