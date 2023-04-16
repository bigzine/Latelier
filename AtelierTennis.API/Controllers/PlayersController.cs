using AtelierTennis.API.ServiceError;
using AtelierTennis.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AtelierTennis.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayersController : ApiController
{
    private readonly IPlayersService _playersService;

    public PlayersController(IPlayersService playersService)
    {
        _playersService = playersService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> Get()
    {
        var getPlayerResult = await _playersService.GetAllPlayers();
        return getPlayerResult.Match(Ok,Problem);
    }
}
