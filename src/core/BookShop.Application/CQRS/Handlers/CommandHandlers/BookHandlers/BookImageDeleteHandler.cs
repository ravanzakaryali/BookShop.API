using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.BookResponse;
using BookShop.Application.CQRS.Commands.Request.BookRequest;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BookHandlers;

public class BookImageDeleteHandler : IRequestHandler<BookImageDeleteRequest, BookImageDeleteResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public BookImageDeleteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BookImageDeleteResponse> Handle(BookImageDeleteRequest request, CancellationToken cancellationToken)
    {
        Book? book = await _unitOfWork.BookRepository.GetAsync(b => b.NormalizationName == request.BookName, includes: "BookImages");
        if (book is null) throw new Exception(); //Todo: Book exception
        BookImage? blogImage = book.BookImages.FirstOrDefault(i => i.Id == request.ImageId);
        if (blogImage is null) throw new Exception(); //Todo: BookImage exception
        book.BookImages.Remove(blogImage);
        await _unitOfWork.SaveChangesAsync();
        return new BookImageDeleteResponse();
    }
}
