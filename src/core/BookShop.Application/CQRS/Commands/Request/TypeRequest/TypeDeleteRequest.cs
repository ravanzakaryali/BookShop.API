using BookShop.Application.CQRS.Commands.Reponse.TypeResponse;

namespace BookShop.Application.CQRS.Commands.Request.TypeRequest;

public record TypeDeleteRequest(string Id) : IRequest<TypeDeleteResponse>;
