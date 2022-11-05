using BookShop.Application.CQRS.Commands.Reponse.FormatResponse;

namespace BookShop.Application.CQRS.Commands.Request.FormatRequest;

public record FormatDeleteRequest(string Id) : IRequest<FormatDeleteResponse>;
