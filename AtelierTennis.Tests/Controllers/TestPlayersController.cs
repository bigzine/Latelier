using AtelierTennis.API.Controllers;
using AtelierTennis.API.Models;
using AtelierTennis.API.ServiceError;
using AtelierTennis.API.Services.Interfaces;
using AtelierTennis.Tests.Fixtures;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Shouldly;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace AtelierTennis.Tests.Controllers
{
    public  class TestPlayersController
    {
        [Test]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.GetAllPlayers()).ReturnsAsync(PlayersFixture.GetTestPlayers());

            var sut = new PlayersController(mockPlayerService.Object);

            //Act
            var result = (OkObjectResult)await  sut.Get();

            //Assert
            result.StatusCode.ShouldBe(200);
        }

        [Test]
        public async Task Get_OnSuccess_InvokePlayersServiceExactlyOnce()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.GetAllPlayers()).ReturnsAsync(PlayersFixture.GetTestPlayers());
                
            var sut = new PlayersController(mockPlayerService.Object);

            //Act
           await sut.Get();

            //Assert
            mockPlayerService.Verify(p=>p.GetAllPlayers(), Times.Once);
        }

        [Test]
        public async Task Get_OnSuccess_ReturnsListOfPlayers()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.GetAllPlayers()).ReturnsAsync(PlayersFixture.GetTestPlayers());

            var sut = new PlayersController(mockPlayerService.Object);

            //Act
            var result = (OkObjectResult)await sut.Get();

            //Assert
            result.ShouldBeOfType<OkObjectResult>();
            result.Value.ShouldBeOfType<List<Player>>();
        }

        [Test]
        public async Task Get_OnNoPlayersFound_Returns404()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.GetAllPlayers()).ReturnsAsync(Errors.Player.NotFound);

            var sut = new PlayersController(mockPlayerService.Object);

            //Act
            var result = (ObjectResult)await sut.Get();

            //Assert
            result.StatusCode.ShouldBe(404);
        }

        [Test]
        public async Task Get_OnServiceUnavailable_Returns500()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.GetAllPlayers()).ReturnsAsync(Errors.Player.Unavailable);

            var sut = new PlayersController(mockPlayerService.Object);

            //Act
            var result = (ObjectResult)await sut.Get();

            //Assert
            result.StatusCode.ShouldBe(500);
        }

        [Test]
        public async Task GetPlayer_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.Get(It.IsAny<int>())).ReturnsAsync(PlayersFixture.GetTestPlayers().First());

            var sut = new PlayersController(mockPlayerService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetPlayer(1);

            //Assert
            result.StatusCode.ShouldBe(200);
        }

        [Test]
        public async Task GetPlayer_OnSuccess_InvokePlayersServiceExactlyOnce()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.Get(It.IsAny<int>())).ReturnsAsync(PlayersFixture.GetTestPlayers().First());

            var sut = new PlayersController(mockPlayerService.Object);

            //Act
            await sut.GetPlayer(1);

            //Assert
            mockPlayerService.Verify(p => p.Get(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task GetPlayer_OnSuccess_ReturnsPlayer()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.Get(It.IsAny<int>())).ReturnsAsync(PlayersFixture.GetTestPlayers().First());

            var sut = new PlayersController(mockPlayerService.Object);


            //Act
            var result = (OkObjectResult)await sut.GetPlayer(1);

            //Assert
            result.ShouldBeOfType<OkObjectResult>();
            result.Value.ShouldBeOfType<Player>();
        }

        [Test]
        public async Task GetPlayer_OnNoPlayersFound_Returns404()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.Get(It.IsAny<int>())).ReturnsAsync(Errors.Player.NotFound);

            var sut = new PlayersController(mockPlayerService.Object);


            //Act
            var result = (ObjectResult)await sut.GetPlayer(44);

            //Assert
            result.StatusCode.ShouldBe(404);
        }

        [Test]
        public async Task GetPlayer_OnServiceUnavailable_Returns500()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.Get(It.IsAny<int>())).ReturnsAsync(Errors.Player.Unavailable);

            var sut = new PlayersController(mockPlayerService.Object);

            //Act
            var result = (ObjectResult)await sut.GetPlayer(44);

            //Assert
            result.StatusCode.ShouldBe(500);
        }

        [Test]
        public async Task GetStats_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.GetStats()).ReturnsAsync(StatsFixture.GetStats);

            var sut = new PlayersController(mockPlayerService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetStats();

            //Assert
            result.StatusCode.ShouldBe(200);
        }

        [Test]
        public async Task GetStats_OnSuccess_InvokePlayersServiceExactlyOnce()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.GetStats()).ReturnsAsync(StatsFixture.GetStats);

            var sut = new PlayersController(mockPlayerService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetStats();

            //Assert
            mockPlayerService.Verify(p => p.GetStats(), Times.Once);
        }

        [Test]
        public async Task GetStats_OnSuccess_ReturnsPlayer()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.GetStats()).ReturnsAsync(StatsFixture.GetStats);

            var sut = new PlayersController(mockPlayerService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetStats();

            //Assert
            result.ShouldBeOfType<OkObjectResult>();
            result.Value.ShouldBeOfType<Stats>();
        }

        [Test]
        public async Task GetStats_OnNoPlayersFound_Returns404()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.GetStats()).ReturnsAsync(Errors.Player.NotFound);

            var sut = new PlayersController(mockPlayerService.Object);

            //Act
            var result = (ObjectResult)await sut.GetStats();

            //Assert
            result.StatusCode.ShouldBe(404);
        }

        [Test]
        public async Task GetStats_OnServiceUnavailable_Returns500()
        {
            //Arrange
            var mockPlayerService = new Mock<IPlayersService>();
            mockPlayerService
                .Setup(s => s.GetStats()).ReturnsAsync(Errors.Player.Unavailable);

            var sut = new PlayersController(mockPlayerService.Object);

            //Act
            var result = (ObjectResult)await sut.GetStats();

            //Assert
            result.StatusCode.ShouldBe(500);
        }

    }
}
