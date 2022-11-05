using BookShop.Application.CQRS.Commands.Reponse.CategoryResponse;
using BookShop.Application.DTOs.CategoryDtos;

namespace BookShop.Application.CQRS.Commands.Request.CategoryRequest;

public record CategoryUpdateRequest(string Id,CategoryCommandDto Category) : IRequest<CategoryUpdateResponse>;
