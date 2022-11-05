using BookShop.Application.CQRS.Commands.Request.BookRequest;

namespace BookShop.Application.CQRS.Commands.Request.BlogRequest;

public record BlogImageDeleteRequest(string BlogName,string ImageId) : IRequest<BlogImageDeleteResponse>;
