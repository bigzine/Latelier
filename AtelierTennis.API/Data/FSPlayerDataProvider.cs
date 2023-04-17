using AtelierTennis.API.Models;
using AtelierTennis.API.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AtelierTennis.API.Data;

public class FsPlayerDataProvider : IPlayerDataProvider
{
    private readonly string _playerFilePath;
    public FsPlayerDataProvider(IOptions<PlayerDataOptions> options)
    {
        _playerFilePath = options.Value.Path;
    }

    public async Task<List<Player>?> Get()
    {
        var file = await File.ReadAllTextAsync(_playerFilePath);
        var players = JsonConvert.DeserializeObject<JObject>(file)["players"].ToObject<List<Player>>();
        return players;
    }

}