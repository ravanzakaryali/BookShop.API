using BookShop.Application.CQRS.Commands.Reponse.UserResponse;

namespace BookShop.Application.CQRS.Commands.Request.UserRequest;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}
