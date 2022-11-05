using BookShop.Application.CQRS.Commands.Reponse.TypeResponse;
using BookShop.Application.DTOs.TypeDtos;

namespace BookShop.Application.CQRS.Commands.Request.TypeRequest;

public record TypeUpdateRequest(string Id,TypeCommandDto Type) : IRequest<TypeUpdateResponse>;
