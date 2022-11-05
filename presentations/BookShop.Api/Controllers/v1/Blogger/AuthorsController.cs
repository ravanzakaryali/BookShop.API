using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using BookShop.Application.CQRS.Queries.Request.AuthorRequest;
using BookShop.Application.DTOs.AuthorDtos;

namespace BookShop.Api.Controllers.v1.Blogger;

public class AuthorsController : VendorApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page, [FromQuery] int size)
        => Ok(await Mediator.Send(new AuthorGetAllRequest(page, size)));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
        => Ok(await Mediator.Send(new AuthorGetRequest(id)));

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] AuthorCreateRequest request)
        => Ok(await Mediator.Send(request));

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] AuthorCommandDto author)
        => Ok(await Mediator.Send(new AuthorUpdateRequest { Author = author, Id = id }));

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        => Ok(await Mediator.Send(new AuthorDeleteRequest(id)));
}

