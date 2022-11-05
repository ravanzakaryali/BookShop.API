using BookShop.Application.CQRS.Queries.Response.CategoryResponse;

namespace BookShop.Application.CQRS.Queries.Request.CategoryRequest;

public record CategoryGetRequest(string Id) : IRequest<CategoryGetResponse>;
