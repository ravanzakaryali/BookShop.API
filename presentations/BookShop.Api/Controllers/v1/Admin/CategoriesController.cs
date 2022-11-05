using BookShop.Application.CQRS.Commands.Request.CategoryRequest;
using BookShop.Application.CQRS.Queries.Request.CategoryRequest;
using BookShop.Application.DTOs.CategoryDtos;

namespace BookShop.Api.Controllers.v1.Admin;

public class CategoriesController : AdminApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page, [FromQuery] int size)
        => Ok(await Mediator.Send(new CategoryGetAllRequest(page, size)));
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
        => Ok(await Mediator.Send(new CategoryGetRequest(id)));

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromBody] CategoryCreateRequest request)
        => Ok(await Mediator.Send(request));

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] CategoryCommandDto category)
        => Ok(await Mediator.Send(new CategoryUpdateRequest(id, category)));

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] string id)
        => Ok(await Mediator.Send(new CategoryDeleteRequest(id)));

    [HttpPost("{id}/sub-category-create")]
    public async Task<IActionResult> SubCategoryCreate([FromRoute] string id, [FromBody] CategoryCommandDto category)
        => Ok(await Mediator.Send(new SubCategoryCreateRequest(id, category)));

   
}
