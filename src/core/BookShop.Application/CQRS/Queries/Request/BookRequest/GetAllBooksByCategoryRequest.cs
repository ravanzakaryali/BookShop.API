using BookShop.Application.CQRS.Queries.Response.BookResponse;

namespace BookShop.Application.CQRS.Queries.Request.BookRequest;

public record GetAllBooksByCategoryRequest(int Page,int Size,string CategoryId) : IRequest<List<GetAllBookQueryResponse>>;
