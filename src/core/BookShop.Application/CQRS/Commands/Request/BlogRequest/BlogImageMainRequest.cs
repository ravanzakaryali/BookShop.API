using BookShop.Application.CQRS.Commands.Reponse.BlogResponse;

namespace BookShop.Application.CQRS.Commands.Request.BlogRequest;

public record BlogImageMainRequest(string BlogName,string ImageId) : IRequest<BlogImageMainResponse>;
