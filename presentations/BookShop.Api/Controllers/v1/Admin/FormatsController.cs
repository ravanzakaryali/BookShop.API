using BookShop.Application.CQRS.Commands.Request.FormatRequest;
using BookShop.Application.CQRS.Queries.Request.FormatRequest;
using BookShop.Application.DTOs;

namespace BookShop.Api.Controllers.v1.Admin;

public class FormatsController : AdminApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int size)
        => Ok(await Mediator.Send(new FormatGetAllRequest(page, size)));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
        => Ok(await Mediator.Send(new FormatGetRequest(id)));

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] FormatCreateRequest request)
        => Ok(await Mediator.Send(request));

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateAsync([FromQuery] string id, [FromBody] FormatCommandDto format)
        => Ok(await Mediator.Send(new FormatUpdateRequest(id, format)));

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromQuery] string id)
       => Ok(await Mediator.Send(new FormatDeleteRequest(id)));
}
