using BookShop.Application.Common;
using Microsoft.AspNetCore.Authorization;

namespace BookShop.Api.Controllers.v1.Base;

[Authorize]
[Route("api/v{ver:apiVersion}/vendor/[controller]")]
public class VendorApiController : ApiController
{
}
