using BookShop.Application.Asbtarcts.Services;
using BookShop.Application.Common;
using BookShop.Application.CQRS.Commands.Reponse.UserResponse;
using BookShop.Application.CQRS.Commands.Request.UserRequest;
using BookShop.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.UserHandlers;

internal class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;

    public LoginCommandHandler(ITokenService tokenService, UserManager<AppUser> userManager)
    {
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        AppUser user = await _userManager.FindByNameAsync(request.UserName);
        if (user is null)
            throw new Exception("User not found"); //TODO: Exception
        if (!await _userManager.CheckPasswordAsync(user, request.Password))
            throw new Exception("Unauthorized"); //TODO: Exception
        string token = _tokenService.GenerateToken(user, await _userManager.GetRolesAsync(user));
        return new LoginCommandResponse(token);
    }
}
