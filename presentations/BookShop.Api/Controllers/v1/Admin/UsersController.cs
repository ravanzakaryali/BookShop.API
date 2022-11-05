using BookShop.Application.Common;
using BookShop.Application.CQRS.Commands.Request.UserRequest;
using BookShop.Application.CQRS.Queries.Request.UserRequest;

namespace BookShop.Api.Controllers.v1.Admin;

public class UsersController : AdminApiController
{
    [HttpPost("{userName}/add-role/")]
    public async Task<IActionResult> AddRoleAsync([FromRoute] string userName, [FromQuery] AppRoles role)
        => Ok(await Mediator.Send(new UserAddRoleRequest { UserName = userName, Role = role }));

    [HttpGet("{userName}/role")]
    public async Task<IActionResult> GetRoleAsync([FromRoute] string userName)
        => Ok(await Mediator.Send(new UserGetRoleRequest(userName)));
}
