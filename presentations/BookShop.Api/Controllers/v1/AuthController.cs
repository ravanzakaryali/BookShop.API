using BookShop.Application.CQRS.Commands.Request.UserRequest;

namespace BookShop.Api.Controllers.v1;

public class AuthController : ApplicationApiController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommandRequest request)
    {
        return Ok(await Mediator.Send(request));
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommandRequest request)
    {
        return Ok(await Mediator.Send(request));
    }
}
