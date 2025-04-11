using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.RandomNumber
{
    public class RandomNumberService : IRandomNumber
    {
        public RandomNumberService() { }
        public int generateRandomNumberBetween0and36()
        {
            return new Random().Next(0, 35);
        }

    }
}
