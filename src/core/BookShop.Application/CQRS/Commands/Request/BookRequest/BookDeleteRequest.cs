using BookShop.Application.CQRS.Commands.Reponse.BookResponse;

namespace BookShop.Application.CQRS.Commands.Request.BookRequest;

public record BookDeleteRequest(string Bookname) : IRequest<BookDeleteResponse>;
