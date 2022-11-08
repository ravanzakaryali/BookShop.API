using BookShop.Application.CQRS.Commands.Reponse.BookResponse;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.CQRS.Commands.Request.BookRequest;

public class BookCreateRequest : IRequest<BookCreateResponse>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string VendorId { get; set; } = null!;
    public decimal? Price { get; set; }
    public string CategoryId { get; set; } = null!;
    public string? TypeId { get; set; }
    public int ImageMainTh { get; set; } 
    public IFormFileCollection Files { get; set; } = null!;
}
