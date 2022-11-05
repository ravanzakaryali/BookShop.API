using BookShop.Application.Common;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Queries.Response.AuthorResponse;

public class AuthorGetAllResponse : IMapFrom<Author>
{
    public string Name { get; set; } = null!;
    public string AuthorImageId { get; set; } = null!;
    public string AuthorName { get; set; } = null!;
    public ImageGetDto AuthorImage { get; set; } = null!;
}
