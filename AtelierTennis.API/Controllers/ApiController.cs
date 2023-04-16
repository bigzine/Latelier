using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace AtelierTennis.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController: ControllerBase
{
    [ApiExplorerSettings(IgnoreApi = true)]

    protected IActionResult Problem(List<Error> errors)
    {
        var firstError = errors.First();
        var code = firstError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
           _ => StatusCodes.Status500InternalServerError
        };
        return Problem(statusCode: code, title: firstError.Description);
    }
    
}