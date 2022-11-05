using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.BookResponse;
using BookShop.Application.CQRS.Commands.Request.BookRequest;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BookHandlers;

public class BookDeleteHandler : IRequestHandler<BookDeleteRequest, BookDeleteResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public BookDeleteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<BookDeleteResponse> Handle(BookDeleteRequest request, CancellationToken cancellationToken)
    {
        Book? book = await _unitOfWork.BookRepository.GetAsync(p => p.NormalizationName == request.Bookname.Trim().ToLower());
        if (book is null) throw new Exception("Book not found"); //Todo: Exception
        _unitOfWork.BookRepository.Remove(book);
        await _unitOfWork.SaveChangesAsync();
        return new BookDeleteResponse(book.NormalizationName);
    }
}
