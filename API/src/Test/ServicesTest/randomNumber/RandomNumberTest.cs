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

        [Fact]
        public void GenerateRandomColorBetweenRedAndBlack_ShouldReturnRedOrBlack()
        {
            // Arrange
            var service = new RandomNumberService();

            // Act
            var result = service.generateRandomColorBetweenRedAndBlack();

            // Assert
            Assert.Contains(result, new[] { "rojo", "negro" });
        }

        [Fact]
        public void GenerateRandomColorBetweenRedAndBlack_ShouldReturnBothColorsOverMultipleCalls()
        {
            // Arrange
            var service = new RandomNumberService();
            var results = new HashSet<string>();

            // Act
            for (int i = 0; i < 100; i++)
            {
                results.Add(service.generateRandomColorBetweenRedAndBlack());
            }

            // Assert
            Assert.Contains("rojo", results);
            Assert.Contains("negro", results);
        }
    }
}
