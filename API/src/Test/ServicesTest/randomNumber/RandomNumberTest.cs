using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services.RandomNumber;

namespace Test.ServicesTest.randomNumber
{
    public class RandomNumberTest
    {
        [Fact]
        [Trait("Category","GetRandonNumber")]
        public void GenerateRandomNumberBetween0And36_ShouldReturnNumberInRange()
        {
            // Arrange
            var service = new RandomNumberService();

            // Act
            var result = service.generateRandomNumberBetween0and36();

            // Assert
            Assert.InRange(result, 0, 36);
        }
    }
}
