using Microsoft.AspNetCore.Authorization;

namespace BookShop.Api.Controllers.v1.Base;

[Authorize(Roles = "Blogger")]
[Route("api/v{ver:apiVersion}/blogger/[controller]")]
public class BloggerApiController : ApiController
{   
}
