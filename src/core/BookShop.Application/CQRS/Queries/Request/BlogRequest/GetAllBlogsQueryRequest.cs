using BookShop.Application.CQRS.Queries.Response.BlogReponse;

namespace BookShop.Application.CQRS.Queries.Request.BlogRequest;

public record GetAllBlogsQueryRequest(int Page,int Size) : IRequest<IEnumerable<GetAllBlogsResponse>>;
