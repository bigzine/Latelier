using AtelierTennis.API.Data;
using AtelierTennis.API.Models;
using AtelierTennis.API.ServiceError;
using AtelierTennis.API.Services.Interfaces;
using ErrorOr;

namespace AtelierTennis.API.Services;

public class PlayersService : IPlayersService
{
    private readonly IPlayerDataProvider _playerDataProvider;

    public PlayersService(IPlayerDataProvider playerDataProvider)
    {
        _playerDataProvider = playerDataProvider;
    }

    public async Task<ErrorOr<List<Player>>> GetAllPlayers()
    {
        var players = await _playerDataProvider.Get();
        if (players == null)
            return Errors.Player.Unavailable;
        if (!players.PlayerList.Any())
            return Errors.Player.NotFound;
        var orderPlayers = players.PlayerList.OrderBy(p => p.Data.Rank).Select(p => p);
        return orderPlayers.ToList();
    }

    public async Task<ErrorOr<Player>> Get(int id)
    {
        var players = await _playerDataProvider.Get();
        if (players == null)
            return Errors.Player.Unavailable;
        var player = players.PlayerList.FirstOrDefault(p => p.Id == id);
        if(player==null) return Errors.Player.NotFound;
        return player;
    }

    public async Task<ErrorOr<Stats>> GetStats()
    {
        var players = await _playerDataProvider.Get();
        if (players == null)
            return Errors.Player.Unavailable;
        if (!players.PlayerList.Any())
            return Errors.Player.NotFound;
        var stats = GetStats(players.PlayerList);
        return stats;
    }

    private Stats GetStats(List<Player> players)
    {
        var countryWithHighestWinRatio = players
            .GroupBy(p => p.Country.Code)
            .Select(group => new
            {
                Country = group.Key,
                WinRatio = group.Sum(p => p.Data.Last.Count(x => x == 1)) / (double)group.Sum(p => p.Data.Last.Count())
            })
            .OrderByDescending(x => x.WinRatio)
            .First()
            .Country;

        var averageBMI = players.Average(p => p.Data.Weight/1000.0 / Math.Pow(p.Data.Height / 100.0, 2));
        var roundBmi = Math.Round(averageBMI, 2);

        var heights = players.Select(p => p.Data.Height).OrderBy(x => x).ToList();
        double medianHeight;
        if (heights.Count % 2 == 0)
            medianHeight = (heights[heights.Count / 2 - 1] + heights[heights.Count / 2]) / 2.0;
        else
            medianHeight = heights[heights.Count / 2];

        return new Stats()
        {
            AverageBodyMassIndex = roundBmi,
            CountryWithHighestWinRatio = countryWithHighestWinRatio,
            MedianeHeight = medianHeight
        };
    }

}