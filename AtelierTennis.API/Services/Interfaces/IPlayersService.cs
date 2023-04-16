using AtelierTennis.API.Models;
using ErrorOr;

namespace AtelierTennis.API.Services.Interfaces;

public interface IPlayersService
{
   public   Task<ErrorOr<List<Player>>> GetAllPlayers();
}