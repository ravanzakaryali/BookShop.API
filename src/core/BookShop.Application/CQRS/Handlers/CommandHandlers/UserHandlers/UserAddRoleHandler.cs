using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.UserResponse;
using BookShop.Application.CQRS.Commands.Request.UserRequest;
using BookShop.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.UserHandlers;

internal class UserAddRoleHandler : IRequestHandler<UserAddRoleRequest, UserAddRoleResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public UserAddRoleHandler(UserManager<AppUser> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UserAddRoleResponse> Handle(UserAddRoleRequest request, CancellationToken cancellationToken)
    {
        AppUser user = await _userManager.FindByNameAsync(request.UserName);
        if (user is null) throw new Exception("User null"); //TODO: Exception user null
        IdentityResult result = await _userManager.AddToRoleAsync(user, request.Role.ToString());
        if (!result.Succeeded) throw new Exception("Add Role exception"); //TODO: Exception user add role
        UserAddRoleResponse response = _mapper.Map<UserAddRoleResponse>(user);
        response.Role = request.Role.ToString();
        return response;
    }
}
