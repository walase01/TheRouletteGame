using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using services.Dto;
using services.Usuario;

namespace roulettegame_api.Controllers
{
    public class UsuarioController(IUsuario usuarioService) : ControllerBase
    {
        [HttpPost("AddNewUserOrAddAmount")]
        public async Task<IActionResult> AddNewUserOrAddAmount([FromBody]UserDto user)
        {
            var response = await usuarioService.AddUser(user);
            return Ok(response);
        }
    }
}
