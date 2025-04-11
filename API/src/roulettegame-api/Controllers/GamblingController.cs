using Microsoft.AspNetCore.Mvc;
using services.Gambling;
using services.Gambling.Dto;

namespace roulettegame_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class GamblingController(IGamblingGame gamblingGame) : ControllerBase
    {
        [HttpGet]
        public IActionResult executeGamblingGame(GamblingRequest request)
        {
            var response = gamblingGame.Gambling(request);
            return Ok(response);
        }
    }
}
