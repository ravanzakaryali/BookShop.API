namespace BookShop.Api.Controllers.v1
{
    public class BooksController : ApiController
    {
        [HttpGet("bookname")]
        public async Task<IActionResult> Get([FromRoute] string bookname) 
            => Ok(await Mediator.Send(new GetBookQueryRequest(bookname)));
    }
}
