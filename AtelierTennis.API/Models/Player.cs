using System.Text.Json.Serialization;

namespace AtelierTennis.API.Models;



public class Players
{
    [JsonPropertyName("players")]
    public List<Player> PlayerList { get; set; }
}

public class Player
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ShortName { get; set; }
    public Country Country { get; set; }
    public string Picture { get; set; }
    public Data Data { get; set; }
    public char Sex { get; set; }
}

public class Country
{
    public string Picture { get; set; }
    public string Code { get; set; }

}

public class Data
{
    public int Rank { get; set; }
    public int Points { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public int Age { get; set; }
    public int[] Last { get; set; }
}