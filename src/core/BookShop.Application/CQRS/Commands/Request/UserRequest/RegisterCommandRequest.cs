using BookShop.Application.Common;
using BookShop.Application.CQRS.Commands.Reponse.UserResponse;

namespace BookShop.Application.CQRS.Commands.Request.UserRequest;

public class RegisterCommandRequest : IRequest<RegisterCommandResponse>
{
    public string Fullname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}
