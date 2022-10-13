using BookShop.Application.CQRS.Queries.Response.BookResponse;
using MediatR;

namespace BookShop.Application.CQRS.Queries.Request.BookRequest;

public record GetAllBooksQueryRequest(int Page,int Size) : IRequest<List<GetAllBookQueryResponse>>;
