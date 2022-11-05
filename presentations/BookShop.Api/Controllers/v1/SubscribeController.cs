namespace BookShop.Api.Controllers.v1;

public class SubscribeController : ApplicationApiController
{
    [HttpPost("{email}")]
    public async Task<IActionResult> SubscribeEmailAsync([FromRoute] string email)
        => Ok();
}
