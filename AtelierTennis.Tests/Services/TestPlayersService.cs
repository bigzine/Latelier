using AtelierTennis.API.Data;
using AtelierTennis.API.Models;
using AtelierTennis.API.Services;
using AtelierTennis.Tests.Fixtures;
using ErrorOr;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace AtelierTennis.Tests.Services
{
    internal class TestPlayersService
    {

        [Test]
        public async Task GetAllPlayers_ReturnsListOfPlayers()
        {
            var mockPlayerDataProvider = new Mock<IPlayerDataProvider>();
           
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(PlayersFixture.GetTestPlayers());
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.GetAllPlayers();
            result.ShouldBeAssignableTo<ErrorOr<List<Player>>>();
        }

        [Test]
        public async Task GetAllPlayers_ReturnsOrderedListOfPlayers()
        {
            var mockPlayerDataProvider = new Mock<IPlayerDataProvider>();
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(PlayersFixture.GetTestPlayers());
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.GetAllPlayers();
            result.Value.First().LastName.ShouldBe("Medvedev");
            result.Value.Last().LastName.ShouldBe("Gasquet");
            result.Value.Count.ShouldBe(3);
        }

        [Test]
        public async Task GetPlayer_ReturnsPlayer()
        {
            var mockPlayerDataProvider = new Mock<IPlayerDataProvider>();
         
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(PlayersFixture.GetTestPlayers());
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.Get(1);
            result.Value.ShouldBeAssignableTo<Player>();
        }

        [Test]
        public async Task GetPlayer_ReturnsErrorNotFound()
        {
            var mockPlayerDataProvider = new Mock<IPlayerDataProvider>();
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(PlayersFixture.GetTestPlayers());
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.Get(55);
            result.ShouldBeAssignableTo<ErrorOr<Player>>();
        }

        [Test]
        public async Task GetPlayer_ReturnsTheCorrectPlayer()
        {
            var mockPlayerDataProvider = new Mock<IPlayerDataProvider>();
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(PlayersFixture.GetTestPlayers());
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.Get(1);
            result.Value.LastName.ShouldBe("Gasquet");
        }

        [Test]
        public async Task GetStats_ReturnsStats()
        {
            var mockPlayerDataProvider = new Mock<IPlayerDataProvider>();
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(PlayersFixture.GetTestPlayers());
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.GetStats();
            result.Value.ShouldBeAssignableTo<Stats>();
        }

        [Test]
        public async Task GetStats_ReturnsErrorNotFound()
        {
            var mockPlayerDataProvider = new Mock<IPlayerDataProvider>();
        
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(PlayersFixture.GetTestPlayers());
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.GetStats();
            result.ShouldBeAssignableTo<ErrorOr<Stats>>();
        }

        [Test]
        public async Task GetStats_ReturnsTheCorrectStats()
        {
            var mockPlayerDataProvider = new Mock<IPlayerDataProvider>();
         
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(PlayersFixture.GetTestPlayers());
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.GetStats();
            result.Value.AverageBodyMassIndex.ShouldBe(24.99);
            result.Value.MedianeHeight.ShouldBe(170);
            result.Value.CountryWithHighestWinRatio.ShouldBe("Rus");
        }
    }
}
