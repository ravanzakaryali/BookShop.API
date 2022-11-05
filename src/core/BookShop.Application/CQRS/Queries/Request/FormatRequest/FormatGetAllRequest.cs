using BookShop.Application.CQRS.Queries.Response.FormatResponse;

namespace BookShop.Application.CQRS.Queries.Request.FormatRequest;

public record FormatGetAllRequest(int Page,int Size) : IRequest<IEnumerable<FormatGetAllResponse>>;
