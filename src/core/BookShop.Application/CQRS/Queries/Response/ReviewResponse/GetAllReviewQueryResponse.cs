using BookShop.Application.Common;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Queries.Response.ReviewResponse;

public class GetAllReviewQueryResponse : IMapFrom<Review>
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public double? Raiting { get; set; }
    public UserGetDto User { get; set; } = null!;
}
