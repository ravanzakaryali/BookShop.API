using BookShop.Application.CQRS.Commands.Reponse.BookResponse;

namespace BookShop.Application.CQRS.Commands.Request.BookRequest;


public record BookImageMainRequest(string BookName, string ImageId) : IRequest<BookImageMainResponse>;
