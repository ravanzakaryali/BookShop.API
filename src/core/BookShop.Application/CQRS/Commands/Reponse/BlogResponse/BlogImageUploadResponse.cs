using BookShop.Application.Common;

namespace BookShop.Application.CQRS.Commands.Reponse.BlogResponse;

public class BlogImageUploadResponse : IMapFrom<BlogImage>
{
    public string Id { get; set; } = null!;
}
