using BookShop.Application.Common;
using BookShop.Application.CQRS.Commands.Reponse.UserResponse;
using BookShop.Application.CQRS.Commands.Request.TypeRequest;
using BookShop.Application.CQRS.Commands.Request.UserRequest;
using BookShop.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.UserHandlers;

internal class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, RegisterCommandResponse>
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<RegisterCommandResponse> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser user = new()
        {
            Email = request.Email,
            UserName = request.Username,
            Fullname = request.Fullname,
        };
        IdentityResult result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded) throw new Exception("User resgiter"); //Todo: Register
        IdentityResult roleResult = await _userManager.AddToRoleAsync(user, AppRoles.Member.ToString());
        if (!roleResult.Succeeded) throw new Exception(); //Role exception
        return new RegisterCommandResponse();
    }
}
