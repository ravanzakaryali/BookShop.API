using BookShop.Application.CQRS.Queries.Response.AuthorResponse;

namespace BookShop.Application.CQRS.Queries.Request.AuthorRequest;

public record AuthorGetAllRequest(int Page,int Size) : IRequest<IEnumerable<AuthorGetAllResponse>>;
