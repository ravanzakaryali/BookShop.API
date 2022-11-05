using BookShop.Application.CQRS.Queries.Response.TypeResponse;

namespace BookShop.Application.CQRS.Queries.Request.TypeRequest;

public record TypeGetAllRequest(int Page,int Size) : IRequest<IEnumerable<TypeGetAllResponse>>;
