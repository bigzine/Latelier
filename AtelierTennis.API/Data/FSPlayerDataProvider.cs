using System.Text.Json;
using AtelierTennis.API.Models;
using AtelierTennis.API.Options;
using Microsoft.Extensions.Options;

namespace AtelierTennis.API.Data;

public class FsPlayerDataProvider : IPlayerDataProvider
{
    private readonly string _playerFilePath;
    public FsPlayerDataProvider(IOptions<PlayerDataOptions> options)
    {
        _playerFilePath = options.Value.Path;
    }

    public async Task<Players?> Get()
    {
        await using var stream = File.OpenRead(_playerFilePath);
        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };
        var players = await JsonSerializer.DeserializeAsync<Players>(stream, options);
        return players;
    }

}