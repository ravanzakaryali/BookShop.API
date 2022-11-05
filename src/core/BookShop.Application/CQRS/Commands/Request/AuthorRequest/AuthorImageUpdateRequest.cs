using BookShop.Application.CQRS.Commands.Reponse.AuthorResponse;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.CQRS.Commands.Request.AuthorRequest;

public record AuthorImageUpdateRequest(string AuthorId,string ImageId,IFormFile Image) : IRequest<AuthorImageUpdateResponse>;
