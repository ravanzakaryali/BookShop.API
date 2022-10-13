namespace BookShop.Application.CQRS.Queries.Response.BlogReponse;

public class GetAllBlogsResponse
{
    public string Title { get; set; } = null!;
    public BlogerUser User { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string NormalizationName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}
