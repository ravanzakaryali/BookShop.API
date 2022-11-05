using BookShop.Application.CQRS.Commands.Reponse.BlogResponse;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.CQRS.Commands.Request.BlogRequest;

public record BlogImageUploadRequest(string BookName, IFormFileCollection Images, int ImageIsMainTh) : 
    IRequest<IEnumerable<BlogImageUploadResponse>>;

