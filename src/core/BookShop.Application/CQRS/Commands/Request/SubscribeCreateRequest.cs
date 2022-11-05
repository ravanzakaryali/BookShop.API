namespace BookShop.Application.CQRS.Commands.Request;

public record SubscribeCreateRequest(string Email) : IRequest;
