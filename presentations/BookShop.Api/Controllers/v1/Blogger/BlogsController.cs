using BookShop.Application.CQRS.Commands.Request.BlogRequest;
using BookShop.Application.CQRS.Queries.Request.BlogRequest;
using BookShop.Application.DTOs;

namespace BookShop.Api.Controllers.v1.Blogger;

public class BlogsController : BloggerApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page, [FromQuery] int size)
       => Ok(await Mediator.Send(new GetAllBlogsQueryRequest(page, size)));

    [HttpGet("{blogName}")]
    public async Task<IActionResult> GetAsync([FromRoute] string blogName)
        => Ok(await Mediator.Send(new GetBlogRequest(blogName)));

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromForm] BlogCreateRequest request)
        => Ok(await Mediator.Send(request));

    [HttpPut("update/{blogName}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string blogName, [FromBody] BlogCommandDto blog)
        => Ok(await Mediator.Send(new BlogUpdateRequest(blogName, blog)));

    [HttpDelete("delete/{blogName}")]
    public async Task<IActionResult> Delete([FromRoute] string blogName)
        => Ok(await Mediator.Send(new BlogDeleteRequest(blogName)));

    [HttpPost("{blogName}/image-upload")]
    public async Task<IActionResult> ImageUploadAsync([FromRoute] string blogName, [FromForm] IFormFileCollection images, [FromBody] int imageIsMainTh = 1)
        => Ok(await Mediator.Send(new BlogImageUploadRequest(blogName, images, imageIsMainTh)));

    [HttpPost("{blogName}/images/{imageId}/main")]
    public async Task<IActionResult> SetMainImageAsync([FromRoute] string blogName, [FromRoute] string imageId)
        => Ok(await Mediator.Send(new BlogImageMainRequest(blogName, imageId)));

}
