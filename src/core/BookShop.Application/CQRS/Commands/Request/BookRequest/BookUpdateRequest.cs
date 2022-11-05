using BookShop.Application.CQRS.Commands.Reponse.BookResponse;
using BookShop.Application.DTOs;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.CQRS.Commands.Request.BookRequest;

public record BookUpdateRequest(string BookName, UpdateBookDto BookDto) : IRequest<BookUpdateResponse>;
