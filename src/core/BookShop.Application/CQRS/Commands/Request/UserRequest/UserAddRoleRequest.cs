using BookShop.Application.Common;
using BookShop.Application.CQRS.Commands.Reponse.UserResponse;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace BookShop.Application.CQRS.Commands.Request.UserRequest;

public record UserAddRoleRequest: IRequest<UserAddRoleResponse>
{
    public string UserName { get; set; } = null!;
    public AppRoles Role { get; set; }
}
