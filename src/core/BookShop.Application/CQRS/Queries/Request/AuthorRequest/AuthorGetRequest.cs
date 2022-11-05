using BookShop.Application.CQRS.Queries.Response.AuthorResponse;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Queries.Request.AuthorRequest;

public record AuthorGetRequest(string AuthorId) : IRequest<AuthorGetResponse>;
