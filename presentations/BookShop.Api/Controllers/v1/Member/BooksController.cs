using BookShop.Application.CQRS.Commands.Request.ReviewRequest;
using BookShop.Application.DTOs.ReviewDtos;

namespace BookShop.Api.Controllers.v1.Member;

public class BooksController : MemberApiController
{
    [HttpPost("{bookName}/reviews")]
    public async Task<IActionResult> CreateReviews([FromRoute] string bookName, [FromBody] ReviewCommandDto review)
        => Ok(await Mediator.Send(new ReviewCreateRequest(bookName,review)));
}
