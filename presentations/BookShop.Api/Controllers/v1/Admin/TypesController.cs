using BookShop.Application.CQRS.Commands.Request.TypeRequest;
using BookShop.Application.CQRS.Queries.Request.TypeRequest;
using BookShop.Application.DTOs.TypeDtos;

namespace BookShop.Api.Controllers.v1.Admin;

public class TypesController : AdminApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] int page,[FromQuery] int size)
        => Ok(await Mediator.Send(new TypeGetAllRequest(page, size)));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
        => Ok(await Mediator.Send(new TypeGetRequest(id)));

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] TypeCreateRequest request) 
        => Ok(await Mediator.Send(request));

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] TypeCommandDto type)
        => Ok(await Mediator.Send(new TypeUpdateRequest(id, type)));

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        => Ok(await Mediator.Send(new TypeDeleteRequest(id)));

}
