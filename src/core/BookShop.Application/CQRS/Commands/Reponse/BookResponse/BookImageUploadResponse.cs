using BookShop.Application.Common;

namespace BookShop.Application.CQRS.Commands.Reponse.BookResponse;

public class BookImageUploadResponse : IMapFrom<BookImage>
{
    public string Id { get; set; } = null!;
}
