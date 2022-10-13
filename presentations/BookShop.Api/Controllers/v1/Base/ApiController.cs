namespace BookShop.Api.Controllers.v1.Base
{
    [ApiVersion("1"), Route("api/v{ver:apiVersion}/[controller]"), ApiController]

    public class ApiController : ControllerBase
    {
        private ISender? _mediator = null;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
