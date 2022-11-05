using BookShop.Application.CQRS.Commands.Request.BookRequest;
using BookShop.Application.DTOs;

namespace BookShop.Api.Controllers.v1.Vendor;

public class BooksController : VendorApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page, [FromQuery] int size)
           => Ok(await Mediator.Send(new GetAllBooksQueryRequest(page, size)));

    [HttpGet("{bookname}")]
    public async Task<IActionResult> Get([FromRoute] string bookname)
        => Ok(await Mediator.Send(new GetBookQueryRequest(bookname)));

    [HttpPost("create")]
    public async Task<IActionResult> CretaeBookAsync([FromForm] BookCreateRequest request)
        => Ok(await Mediator.Send(request));

    [HttpPost("{bookName}/image-upload")]
    public async Task<IActionResult> ImageUpload([FromRoute] string bookName, [FromForm] IFormFileCollection images, [FromForm] int imageIsMainTh)
        => Ok(await Mediator.Send(new BookImageUploadRequest(bookName, images, imageIsMainTh)));

    [HttpPut("update/{bookName}")]
    public async Task<IActionResult> UpdateBookAsync([FromRoute] string bookName, [FromBody] UpdateBookDto bookData)
        => Ok(await Mediator.Send(new BookUpdateRequest(bookName, bookData)));

    [HttpDelete("delete/{bookName}")]
    public async Task<IActionResult> BookDelete([FromRoute] string bookName)
        => Ok(await Mediator.Send(new BookDeleteRequest(bookName)));

    [HttpPost("{blogName}/images/{imageId}/main")]
    public async Task<IActionResult> BookImagesIsMain([FromRoute] string blogName, [FromRoute] string imageId)
        => Ok(await Mediator.Send(new BookImageMainRequest(blogName, imageId)));

}
