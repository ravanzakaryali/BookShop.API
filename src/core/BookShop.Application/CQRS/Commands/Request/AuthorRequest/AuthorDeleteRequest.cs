using BookShop.Application.CQRS.Commands.Reponse.AuthorResponse;

namespace BookShop.Application.CQRS.Commands.Request.AuthorRequest;

public record AuthorDeleteRequest(string Id) : IRequest<AuthorDeleteResponse>;
