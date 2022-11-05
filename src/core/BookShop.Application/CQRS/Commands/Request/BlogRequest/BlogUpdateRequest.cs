using BookShop.Application.CQRS.Commands.Reponse.BlogResponse;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Commands.Request.BlogRequest;

public record BlogUpdateRequest(string BlogName,BlogCommandDto Blog): IRequest<BlogUpdateResponse>;
