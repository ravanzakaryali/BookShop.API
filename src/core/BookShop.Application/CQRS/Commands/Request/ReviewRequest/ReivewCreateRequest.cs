using BookShop.Application.CQRS.Commands.Reponse.ReviewResponse;
using BookShop.Application.DTOs.ReviewDtos;

namespace BookShop.Application.CQRS.Commands.Request.ReviewRequest;

public record ReviewCreateRequest(string BookName,ReviewCommandDto ReviewDto) : IRequest<ReviewCreateResponse>;