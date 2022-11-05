using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Queries.Response.AuthorResponse;

public class AuthorGetResponse
{
    public AuthorGetResponse()
    {
        Awards = new HashSet<AuthorAward>();
    }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string AuthorImageId { get; set; } = null!;
    public string AuthorName { get; set; } = null!;
    public ImageGetDto AuthorImage { get; set; } = null!;
    public ICollection<AuthorAward> Awards { get; set; }
}
