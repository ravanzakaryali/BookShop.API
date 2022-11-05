using BookShop.Application.CQRS.Queries.Response.BlogReponse;

namespace BookShop.Application.CQRS.Queries.Request.BlogRequest;

public record GetBlogRequest(string BookName) : IRequest<GetBlogResponse>;
