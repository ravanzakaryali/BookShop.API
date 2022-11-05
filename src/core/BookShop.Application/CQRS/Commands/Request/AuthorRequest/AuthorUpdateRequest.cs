using BookShop.Application.CQRS.Commands.Reponse.AuthorResponse;
using BookShop.Application.DTOs.AuthorDtos;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.CQRS.Commands.Request.AuthorRequest;

public record AuthorUpdateRequest : IRequest<AuthorUpdateResponse>
{
    public AuthorUpdateRequest()
    {
        Author = new AuthorCommandDto();
    }
    public string Id { get; set; } = null!;
    public AuthorCommandDto Author { get; set; }
}
