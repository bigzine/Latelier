using AtelierTennis.API.Models;
using ErrorOr;

namespace AtelierTennis.API.Services.Interfaces;

public interface IPlayersService
{
    Task<ErrorOr<List<Player>>> GetAllPlayers();
    Task<ErrorOr<Player>> Get(int id);
}