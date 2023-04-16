using AtelierTennis.API.Data;
using AtelierTennis.API.Models;
using AtelierTennis.API.ServiceError;
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
            var players = new Players()
            {
                PlayerList = PlayersFixture.GetTestPlayers()
            };
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(players);
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.GetAllPlayers();
            result.ShouldBeAssignableTo<ErrorOr<List<Player>>>();
        }

        [Test]
        public async Task GetAllPlayers_ReturnsOrderedListOfPlayers()
        {
            var mockPlayerDataProvider = new Mock<IPlayerDataProvider>();
            var players = new Players()
            {
                PlayerList = PlayersFixture.GetTestPlayers()
            };
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(players);
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.GetAllPlayers();
           Assert.That("Medvedev", Is.EqualTo(result.Value.First().LastName));
           Assert.That("Gasquet", Is.EqualTo(result.Value.Last().LastName));
           result.Value.Count.ShouldBe(3);
        }

        [Test]
        public async Task GetPlayer_ReturnsPlayer()
        {
            var mockPlayerDataProvider = new Mock<IPlayerDataProvider>();
            var players = new Players()
            {
                PlayerList = PlayersFixture.GetTestPlayers()
            };
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(players);
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.Get(1);
            result.ShouldBeAssignableTo<Player>();
        }

        [Test]
        public async Task GetPlayer_ReturnsErrorNotFound()
        {
            var mockPlayerDataProvider = new Mock<IPlayerDataProvider>();
            var players = new Players()
            {
                PlayerList = PlayersFixture.GetTestPlayers()
            };
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(players);
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.Get(55);
            result.ShouldBeAssignableTo<ErrorOr<Player>>();
            
        }

        [Test]
        public async Task GetPlayer_ReturnsAPlayer()
        {
            var mockPlayerDataProvider = new Mock<IPlayerDataProvider>();
            var players = new Players()
            {
                PlayerList = PlayersFixture.GetTestPlayers()
            };
            mockPlayerDataProvider.Setup(s => s.Get()).ReturnsAsync(players);
            var service = new PlayersService(mockPlayerDataProvider.Object);
            var result = await service.Get(1);
            result.Value.LastName.ShouldBe("Gasquet");
        }
    }
}
