using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using services.RandomNumber;

namespace roulettegame_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomNumberController (IRandomNumber service) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRandomNumber()
        {
            var response = service.generateRandomNumberBetween0and36();
            return Ok(response);
        }
    }
}
