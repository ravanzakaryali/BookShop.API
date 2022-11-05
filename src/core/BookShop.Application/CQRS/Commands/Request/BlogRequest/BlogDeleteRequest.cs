using BookShop.Application.CQRS.Commands.Reponse.BlogResponse;

namespace BookShop.Application.CQRS.Commands.Request.BlogRequest;

public record BlogDeleteRequest(string BlogName) : IRequest<BlogDeleteResponse>;
