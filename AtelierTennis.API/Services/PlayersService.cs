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

}