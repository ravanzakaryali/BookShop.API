namespace BookShop.Api.Controllers.v1.Base
{
    [ApiVersion("1"), ApiController]
    public class ApiController : ControllerBase
    {
        private ISender? _mediator = null;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
