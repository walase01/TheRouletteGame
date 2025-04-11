using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services.Gambling.Dto;
using services.RandomNumber;

namespace services.Gambling
{
    public class GamblingGame(IRandomNumber randomNumber) : IGamblingGame
    {

        public async Task<WinInfoByUser> Gambling(GamblingRequest request)
        {
            double award = 0;
            bool successful = false;

            var winNumber = randomNumber.generateRandomNumberBetween0and36();
            var winColor = (winNumber % 2 == 0) ? "rojo" : "negro";

            //validate if the number and color are correct 
            if (request.Number == winNumber &&
                request.Color.ToLower() == winColor)
            {
                award = request.Amount * 3;
                successful = true;
            }
            //validate odd or even + color
            else if (request.Type != null &&
                     request.Color.ToLower() == winColor &&
                    ((request.Type == "par" && winNumber % 2 == 0) || (request.Type == "impar" && winNumber % 2 != 0)))
            {
                award = request.Amount;
                successful = true;
            }
            //validate the color 
            else if (request.Type == null && request.Color.ToLower() == winColor)
            {
                award = request.Amount * 0.5;
                successful = true;
            }

            double resultado = successful ? award : -request.Amount;

            return new WinInfoByUser()
            {
                Award = award,
                Successful = successful,
                WinningColor = winColor,
                WinningNumber = winNumber
            };
        }
    }
}
