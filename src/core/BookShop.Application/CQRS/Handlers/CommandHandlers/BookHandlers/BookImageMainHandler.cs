﻿using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Request.BookRequest;
using BookShop.Application.Exceptions;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BookHandlers;

public class BookImageMainHandler : IRequestHandler<BookImageMainRequest, BookImageMainResponse>
{
    public readonly IUnitOfWork _unitOfWork;
    public BookImageMainHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<BookImageMainResponse> Handle(BookImageMainRequest request, CancellationToken cancellationToken)
    {
        Book? book = await _unitOfWork.BookRepository.GetAsync(b => b.NormalizationName == request.BookName, includes: "BookImages");
        if (book is null) throw new EntityNotFoundException<Book, string>(request.BookName);

        book.BookImages.ToList().ForEach(c => c.IsMain = false);
        BookImage? bookImage = book.BookImages.FirstOrDefault(b => b.Id == request.ImageId);
        if (bookImage is null) throw new EntityNotFoundException<BookImage, string>(request.ImageId);
        bookImage.IsMain = true;
        await _unitOfWork.SaveChangesAsync();
        return new BookImageMainResponse();
    }
}
