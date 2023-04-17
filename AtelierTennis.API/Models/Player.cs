using System.Text.Json.Serialization;

namespace AtelierTennis.API.Models;

public class Player
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string ShortName { get; set; }
    public required Country Country { get; set; }
    public required string Picture { get; set; }
    public required Data Data { get; set; }
    public char Sex { get; set; }
}

public class Country
{
    public required string Picture { get; set; }
    public required string Code { get; set; }

}

public class Data
{
    public int Rank { get; set; }
    public int Points { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public int Age { get; set; }
    public required int[] Last { get; set; }
}