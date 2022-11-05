using BookShop.Application.CQRS.Commands.Reponse.FormatResponse;

namespace BookShop.Application.CQRS.Commands.Request.FormatRequest;

public record FormatCreateRequest(string Name) : IRequest<FormatCreateResponse>;
