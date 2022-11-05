using BookShop.Application.CQRS.Queries.Response.FormatResponse;

namespace BookShop.Application.CQRS.Queries.Request.FormatRequest;

public record FormatGetRequest(string Id) : IRequest<FormatGetResponse>;
