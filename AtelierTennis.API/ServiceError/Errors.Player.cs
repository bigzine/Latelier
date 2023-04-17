
using ErrorOr;

namespace AtelierTennis.API.ServiceError;

public static class Errors
{
    public static class Player
    {
        public static Error Unavailable => Error.Custom(
            503,"PlayersList.Unavailable",
            "Cannot get player list");
        public static Error NotFound => Error.NotFound("Player.NotFound","A not found error occurred");
    }
    
}