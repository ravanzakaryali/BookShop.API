using BookShop.Application.Common;
using BookShop.Domain.Identity;

namespace BookShop.Application.CQRS.Commands.Reponse.UserResponse;

public class UserAddRoleResponse : IMapFrom<AppUser>
{
    public string Id { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Role { get; set; } = null!;
}
