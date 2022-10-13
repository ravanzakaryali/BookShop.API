using BookShop.Application.CQRS.Queries.Response.ReviewResponse;

namespace BookShop.Application.CQRS.Queries.Request.ReviewRequest;

public record GetAllReviewByBookRequest(string BookUrlName) : IRequest<IEnumerable<GetAllReviewQueryResponse>>;
