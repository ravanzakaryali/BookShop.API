using BookShop.Application.CQRS.Commands.Reponse.TypeResponse;

namespace BookShop.Application.CQRS.Commands.Request.TypeRequest;

public record TypeCreateRequest(string Name) : IRequest<TypeCreateResponse>;
