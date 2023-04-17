using AtelierTennis.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AtelierTennis.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayersController : ApiController
{
    private readonly IPlayersService _playersService;
    private readonly ILogger<PlayersController> _logger;

    public PlayersController(IPlayersService playersService, ILogger<PlayersController> logger) : base(logger)
    {
        _playersService = playersService;
        _logger = logger;
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
