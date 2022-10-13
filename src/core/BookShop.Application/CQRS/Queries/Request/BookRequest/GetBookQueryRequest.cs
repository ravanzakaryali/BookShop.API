using BookShop.Application.CQRS.Queries.Response.BookResponse;
using MediatR;

namespace BookShop.Application.CQRS.Queries.Request.BookRequest;

public record GetBookQueryRequest(string BookUrlName) : IRequest<GetBookQueryResponse>;
