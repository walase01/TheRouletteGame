using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services.RandomNumber
{
    public interface IRandomNumber
    {
        int generateRandomNumberBetween0and36();
        string generateRandomColorBetweenRedAndBlack();
    }
}
