using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using services.Gambling.Dto;
using services.RandomNumber;
using services.Response;

namespace services.Gambling
{
    public class GamblingGame(IRandomNumber randomNumber, ILogger<GamblingGame> _logger) : IGamblingGame
    {

        public AppResponse<WinInfoByUser> Gambling(GamblingRequest request)
        {
            try
            {
                var message = "";
                double userTotal = request.UserAmount;
                double award = 0;
                bool successful = false;

                var winNumber = randomNumber.generateRandomNumberBetween0and36();
                var winColor = randomNumber.generateRandomColorBetweenRedAndBlack();

                bool oddOrEven = winNumber % 2 == 0;

                //validate if the number and color are correct 
                if (request.Number == winNumber &&
                    request.Color.Equals(winColor, StringComparison.CurrentCultureIgnoreCase))
                {
                    award = request.Amount * 3;
                    successful = true;
                }
                //validate odd or even + color
                else if (request.Type != null &&
                         request.Color.Equals(winColor, StringComparison.CurrentCultureIgnoreCase) &&
                        ((request.Type == "par" && oddOrEven) || (request.Type == "impar" && !oddOrEven)))
                {
                    award = request.Amount;
                    successful = true;
                }                
                //validate the color 
                else if (request.Type == null && request.Number == -1 && request.Color.Equals(winColor, StringComparison.CurrentCultureIgnoreCase))
                {
                    award = request.Amount * 0.5;
                    successful = true;
                }

                if (successful)
                {
                    userTotal += award;
                    message = $"¡Ganaste! Número {(oddOrEven ? "par" : "impar")} : {winNumber}, Color: {winColor}";
                }
                else
                {
                    userTotal -= request.Amount;
                    award = -request.Amount;
                    message = $"¡Perdiste! Número {(oddOrEven ? "par" : "impar")} : {winNumber}, Color: {winColor}";
                }

                return AppResponse.Success(new WinInfoByUser()
                {
                    Award = award,
                    Successful = successful,
                    WinningColor = winColor,
                    WinningNumber = winNumber,
                    UserAmount = userTotal
                }, message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurred during the execution {E}", ex.Message);

                return AppResponse.Fail<WinInfoByUser>(
                    "Ocurrió un error al agregar el usuario",
                    [new Error(HttpStatusCode.InternalServerError, ex.Message)]
                );
            }
        }
    }
}
