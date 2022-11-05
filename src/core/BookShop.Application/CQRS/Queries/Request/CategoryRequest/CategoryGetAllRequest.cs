using BookShop.Application.CQRS.Queries.Response.CategoryResponse;

namespace BookShop.Application.CQRS.Queries.Request.CategoryRequest;

public record CategoryGetAllRequest(int Page,int Size) : IRequest<IEnumerable<CategoryGetAllResponse>>;
