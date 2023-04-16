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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var getPlayerResult = await _playersService.GetAllPlayers();
        return getPlayerResult.Match(Ok,Problem);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlayer(int id)
    {
        var getPlayerResult = await _playersService.Get(id);
        return getPlayerResult.Match(Ok, Problem);
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats()
    {
        var getPlayerResult = await _playersService.GetStats();
        return getPlayerResult.Match(Ok, Problem);
    }
}
