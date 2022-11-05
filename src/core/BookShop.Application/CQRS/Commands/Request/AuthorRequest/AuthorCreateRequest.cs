using BookShop.Application.Common;
using BookShop.Application.CQRS.Commands.Reponse.AuthorResponse;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.CQRS.Commands.Request.AuthorRequest;

public record AuthorCreateRequest : IRequest<AuthorCreateResponse>, IMapFrom<Author>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public IFormFile ProfileImage { get; set; } = null!;
}
