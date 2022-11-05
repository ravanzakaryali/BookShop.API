namespace BookShop.Api.Controllers.v1
{
    public class BooksController : ApplicationApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page, [FromQuery] int size)
            => Ok(await Mediator.Send(new GetAllBooksQueryRequest(page, size)));

        [HttpGet("{bookname}")]
        public async Task<IActionResult> Get([FromRoute] string bookname)
            => Ok(await Mediator.Send(new GetBookQueryRequest(bookname)));

        [HttpGet("categories/{categoryName}")]
        public async Task<IActionResult> GetAllByCategory([FromQuery] int page, [FromQuery] int size, [FromRoute] string categoryName)
            => Ok(await Mediator.Send(new GetAllBooksByCategoryRequest(page, size, categoryName)));
    }
}
