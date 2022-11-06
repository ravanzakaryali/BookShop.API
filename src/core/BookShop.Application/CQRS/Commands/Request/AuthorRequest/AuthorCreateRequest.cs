using BookShop.Application.Common;
using BookShop.Application.CQRS.Commands.Reponse.AuthorResponse;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.CQRS.Commands.Request.AuthorRequest;

public record AuthorCreateRequest(string Name, string Description, IFormFile ProfileImage) : IRequest<AuthorCreateResponse>, IMapFrom<Author>;
