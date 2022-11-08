using BookShop.Application.CQRS.Commands.Reponse.AuthorResponse;
using BookShop.Application.DTOs.AuthorDtos;

namespace BookShop.Application.CQRS.Commands.Request.AuthorRequest;

public record AuthorUpdateRequest(string Id,AuthorCommandDto Author) : IRequest<AuthorUpdateResponse>;
