using BookShop.Application.CQRS.Commands.Reponse.BookResponse;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.CQRS.Commands.Request.BookRequest;

public record BookImageUploadRequest(string BookName, IFormFileCollection Images, int ImageIsMainTh) : IRequest<IEnumerable<BookImageUploadResponse>>
{
}
