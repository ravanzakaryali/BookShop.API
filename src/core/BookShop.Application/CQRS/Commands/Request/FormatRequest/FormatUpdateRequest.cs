using BookShop.Application.CQRS.Commands.Reponse.FormatResponse;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Commands.Request.FormatRequest;

public record FormatUpdateRequest(string Id,FormatCommandDto Format) : IRequest<FormatUpdateResponse>;
