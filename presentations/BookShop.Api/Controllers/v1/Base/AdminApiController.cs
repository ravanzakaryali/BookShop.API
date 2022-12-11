using Microsoft.AspNetCore.Authorization;

namespace BookShop.Api.Controllers.v1.Base;

[Authorize(Roles = "Admin")]
[Route("api/v{ver:apiVersion}/admin/[controller]")]

public class AdminApiController : ApiController
{
    
}
