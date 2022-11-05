using BookShop.Application.CQRS.Queries.Response.TypeResponse;

namespace BookShop.Application.CQRS.Queries.Request.TypeRequest;

public record TypeGetRequest(string Id) : IRequest<TypeGetResponse>;
