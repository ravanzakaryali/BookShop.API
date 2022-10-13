using BookShop.Application.CQRS.Commands.Reponse.BookResponse;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.CQRS.Commands.Request.BookRequest;

public class CreateBookRequest : IRequest<CreateBookResponse>
{
    public CreateBookRequest()
    {
        Formats = new HashSet<Format>();
        Languages = new HashSet<Language>();
        Authors = new HashSet<Author>();
    }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string VendorId { get; set; } = null!;
    public decimal Price { get; set; }
    public string CategoryId { get; set; } = null!;
    public string? TypeId { get; set; }
    public IFormFileCollection Files { get; set; } = null!;
    //Todo: collectionların hamısında create Dto olacaq 
    public ICollection<Format> Formats { get; set; } 
    public ICollection<Author> Authors { get; set; }
    public ICollection<Language> Languages { get; set; }
}
