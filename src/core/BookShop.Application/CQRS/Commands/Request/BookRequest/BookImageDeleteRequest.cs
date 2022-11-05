using BookShop.Application.CQRS.Commands.Reponse.BookResponse;

namespace BookShop.Application.CQRS.Commands.Request.BookRequest;

public record BookImageDeleteRequest(string BookName,string ImageId) : IRequest<BookImageDeleteResponse>;
