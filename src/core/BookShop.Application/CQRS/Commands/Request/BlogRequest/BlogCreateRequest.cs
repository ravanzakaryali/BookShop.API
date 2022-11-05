using BookShop.Application.CQRS.Commands.Reponse.BlogResponse;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.CQRS.Commands.Request.BlogRequest;

public class BlogCreateRequest : IRequest<BlogCreateResponse>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int ImageMainTh { get; set; }
    public IFormFileCollection Images { get; set; } = null!;
}
