using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BookShop.Api.Controllers.v1.Base;


[Authorize(Roles = "Member")]
[Route("api/v{ver:apiVersion}/member/[controller]")]
public class MemberApiController : ApiController
{
}
