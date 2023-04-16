using AtelierTennis.API.Models;

namespace AtelierTennis.Tests.Fixtures
{
    public static class PlayersFixture
    {
        public static List<Player> GetTestPlayers() => new()
        {
            new Player()
            {
                Country = new Country()
                {
                    Code = "Fra",
                    Picture = string.Empty,
                },
                Picture = string.Empty,
                FirstName = "Richard",
                LastName = "Gasquet",
                ShortName = "R.Gas",
                Sex = 'M',
                Id = 1,
                Data = new Data()
                {
                    Rank = 76,
                    Points = 1000,
                    Weight = 90000,
                    Age = 34,
                    Height = 183,
                    Last = new[] { 1, 0, 0, 0 }
                }
            },
            new Player()
            {
                Country = new Country()
                {
                    Code = "Arg",
                    Picture = string.Empty,
                },
                Picture = string.Empty,
                FirstName = "Diego",
                LastName = "Schwarzman",
                ShortName = "D.Sch",
                Sex = 'M',
                Id = 3,
                Data = new Data()
                {
                    Rank = 20,
                    Points = 1000,
                    Weight = 65000,
                    Age = 34,
                    Height = 170,
                    Last = new[] { 1, 0, 1, 0 }
                }
            },
            new Player()
            {
                Country = new Country()
                {
                    Code = "Rus",
                    Picture = string.Empty,
                },
                Picture = string.Empty,
                FirstName = "Danil",
                LastName = "Medvedev",
                ShortName = "D.Med",
                Sex = 'M',
                Id = 5,
                Data = new Data()
                {
                    Rank = 6,
                    Points = 1000,
                    Weight = 74000,
                    Age = 34,
                    Height = 170,
                    Last = new[] { 1, 1, 1, 1 }
                }
            }
        };
    }
}
