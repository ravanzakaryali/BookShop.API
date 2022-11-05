using BookShop.Application.CQRS.Commands.Reponse.CategoryResponse;
using BookShop.Application.DTOs.CategoryDtos;

namespace BookShop.Application.CQRS.Commands.Request.CategoryRequest;

public record SubCategoryCreateRequest(string CategoryId,CategoryCommandDto Category) : IRequest<SubCategoryCreateResponse>;
