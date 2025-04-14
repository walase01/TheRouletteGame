using Microsoft.AspNetCore.Mvc;
using services.Gambling;
using services.Gambling.Dto;
using services.Response;

namespace roulettegame_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class GamblingController(IGamblingGame gamblingGame) : ControllerBase
    {
        [HttpPost]
        public AppResponse<WinInfoByUser> executeGamblingGame([FromBody]GamblingRequest request)
        {
            var response = gamblingGame.Gambling(request);
            return response;
        }
    }
}
