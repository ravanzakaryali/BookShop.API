using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.ReviewResponse;
using BookShop.Application.CQRS.Commands.Request.ReviewRequest;
using BookShop.Application.Exceptions;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.ReviewHandlers;

public class ReviewCreateHandler : IRequestHandler<ReviewCreateRequest, ReviewCreateResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReviewCreateHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ReviewCreateResponse> Handle(ReviewCreateRequest request, CancellationToken cancellationToken)
    {
        Book? book = await _unitOfWork.BookRepository.GetAsync(b=>b.NormalizationName == request.BookName.Trim().ToLower());//TODO: Bookname trime tolower
        if (book is null) throw new EntityNotFoundException<Book,string>(request.BookName);
        Review review = _mapper.Map<Review>(request.ReviewDto);
        review.BookId = book.Id;
        await _unitOfWork.ReviewRepository.AddAsync(review);

        return new ReviewCreateResponse();
    }
}
