using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services.Gambling.Dto;
using services.Gambling;
using Microsoft.Extensions.Logging;
using services.RandomNumber;
using Moq;
using System.Net;

namespace Test.ServicesTest.Gambling
{
    public class GamblingGameTests
    {
        private readonly Mock<IRandomNumber> _mockRandomNumber = new();
        private readonly Mock<ILogger<GamblingGame>> _mockLogger = new();

        [Fact]
        public void Gambling_WinsFullAward_WhenNumberAndColorMatch()
        {
            // Arrange
            var request = new GamblingRequest
            {
                Number = 10,
                Color = "rojo",
                Type = null,
                Amount = 100,
                UserAmount = 500,
                User = "Jose Ramon"
            };

            _mockRandomNumber.Setup(r => r.generateRandomNumberBetween0and36()).Returns(10);
            _mockRandomNumber.Setup(r => r.generateRandomColorBetweenRedAndBlack()).Returns("rojo");

            var game = new GamblingGame(_mockRandomNumber.Object, _mockLogger.Object);

            // Act
            var response = game.Gambling(request);

            // Assert
            Assert.True(response?.Result?.Successful);
            Assert.Equal(800, response?.Result?.UserAmount); // 500 + (100 * 3)
            Assert.Equal(300, response?.Result?.Award);
            Assert.Equal("rojo", response?.Result?.WinningColor);
            Assert.Equal(10, response?.Result?.WinningNumber);
        }

        [Fact]
        public void Gambling_WinsHalfAward_WhenOnlyColorMatches_AndTypeIsNull()
        {
            // Arrange
            var request = new GamblingRequest
            {
                Number = 7,
                Color = "Black",
                Type = null,
                Amount = 100,
                UserAmount = 500
            };

            _mockRandomNumber.Setup(r => r.generateRandomNumberBetween0and36()).Returns(15); // diff number
            _mockRandomNumber.Setup(r => r.generateRandomColorBetweenRedAndBlack()).Returns("Black");

            var game = new GamblingGame(_mockRandomNumber.Object, _mockLogger.Object);

            // Act
            var response = game.Gambling(request);

            // Assert
            Assert.True(response.Result.Successful);
            Assert.Equal(550, response.Result.UserAmount); // 500 + (100 * 0.5)
            Assert.Equal(50, response.Result.Award);
        }

        [Fact]
        public void Gambling_Loses_WhenNoMatch()
        {
            // Arrange
            var request = new GamblingRequest
            {
                Number = 12,
                Color = "Red",
                Type = null,
                Amount = 100,
                UserAmount = 500
            };

            _mockRandomNumber.Setup(r => r.generateRandomNumberBetween0and36()).Returns(1);
            _mockRandomNumber.Setup(r => r.generateRandomColorBetweenRedAndBlack()).Returns("Black");

            var game = new GamblingGame(_mockRandomNumber.Object, _mockLogger.Object);

            // Act
            var response = game.Gambling(request);

            // Assert
            Assert.False(response.Result.Successful);
            Assert.Equal(400, response.Result.UserAmount); // 500 - 100
            Assert.Equal(-100, response.Result.Award);
        }

        [Fact]
        public void Gambling_ReturnsErrorResponse_OnException()
        {
            // Arrange
            var request = new GamblingRequest
            {
                Number = 5,
                Color = "Red",
                Type = null,
                Amount = 100,
                UserAmount = 500
            };

            _mockRandomNumber.Setup(r => r.generateRandomNumberBetween0and36()).Throws(new Exception("Random failed"));

            var game = new GamblingGame(_mockRandomNumber.Object, _mockLogger.Object);

            // Act
            var response = game.Gambling(request);

            // Assert
            Assert.False(response.Succeeded);
            Assert.Equal("Ocurrió un error al agregar el usuario", response.Message);
            Assert.Single(response.Errors);
            Assert.Equal(HttpStatusCode.InternalServerError, response.Errors[0].StatusCode);
        }
    }
}
