using Microsoft.AspNetCore.Mvc;

namespace AtelierTennis.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly ILogger<PlayerController> _logger;

    public PlayerController(ILogger<PlayerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPlayers")]
    public Task<IActionResult> Get()
    {
        return null;
    }
}
