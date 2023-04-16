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
        public async Task Get_OnServiceUnavailable_Returns404()
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
    }
}
