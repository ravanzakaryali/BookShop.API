using BookShop.Application.CQRS.Queries.Response.UserReponse;

namespace BookShop.Application.CQRS.Queries.Request.UserRequest;

public record UserGetRoleRequest(string UserName) : IRequest<IEnumerable<UserGetRoleResponse>>;
