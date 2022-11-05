using BookShop.Application.CQRS.Queries.Request.UserRequest;
using BookShop.Application.CQRS.Queries.Response.UserReponse;
using BookShop.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.UserHandler;

public class UserGetRoleHandler : IRequestHandler<UserGetRoleRequest, IEnumerable<UserGetRoleResponse>>
{
    private readonly UserManager<AppUser> _userManager;


    public UserGetRoleHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IEnumerable<UserGetRoleResponse>> Handle(UserGetRoleRequest request, CancellationToken cancellationToken)
    {
        AppUser user = await _userManager.FindByNameAsync(request.UserName);
        if (user is null)
            throw new Exception("User not found"); //Todo: User not found custom 1
        IEnumerable<string> roles = await _userManager.GetRolesAsync(user);
        List<UserGetRoleResponse> response = new();
        roles.ToList().ForEach(role => response.Add(new UserGetRoleResponse
        {
            RoleName = role
        }));
        return response;
    }
}
