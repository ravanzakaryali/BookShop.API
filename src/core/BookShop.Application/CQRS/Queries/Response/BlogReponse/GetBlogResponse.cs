using BookShop.Application.Common;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Queries.Response.BlogReponse;

public class GetBlogResponse : IMapFrom<Blog>
{
    public string Title { get; set; } = null!;
    public BlogerUser User { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string NormalizationName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public ICollection<ImageGetDto> BlogImages { get; set; } = null!;
}
