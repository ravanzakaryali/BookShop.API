using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.BookResponse;
using BookShop.Application.CQRS.Commands.Request.BookRequest;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BookHandlers;

public class BookUpdateHandler : IRequestHandler<BookUpdateRequest, BookUpdateResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookUpdateHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookUpdateResponse> Handle(BookUpdateRequest request, CancellationToken cancellationToken)
    {
        Book? book = await _unitOfWork.BookRepository.GetAsync(b => b.NormalizationName == request.BookName, tracking: false);
        if (book is null) throw new Exception("Book Not found");
        Book newBook = _mapper.Map<Book>(request.BookDto);
        newBook.Id = book.Id;
        _unitOfWork.BookRepository.Update(newBook);
        await _unitOfWork.SaveChangesAsync();
        return new BookUpdateResponse();
    }
}
