using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using services.RandomNumber;

namespace roulettegame_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class RandomNumberController (IRandomNumber service) : ControllerBase
    {
        [HttpGet("Number")]
        public int GetRandomNumber()
        {
            var response = service.generateRandomNumberBetween0and36();
            return response;
        }

        [HttpGet("Color")]
        public string GetRandomColor()
        {
            var response = service.generateRandomColorBetweenRedAndBlack();
            return response;
        }
    }
}
