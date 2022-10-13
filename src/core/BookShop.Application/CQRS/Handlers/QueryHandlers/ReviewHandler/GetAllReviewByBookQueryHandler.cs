using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.ReviewRequest;
using BookShop.Application.CQRS.Queries.Response.ReviewResponse;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.ReviewHandler;

public class GetAllReviewByBookQueryHandler : IRequestHandler<GetAllReviewByBookRequest, IEnumerable<GetAllReviewQueryResponse>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllReviewByBookQueryHandler(
        IMapper mapper, 
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<GetAllReviewQueryResponse>> Handle(GetAllReviewByBookRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Review?> reviews = await _unitOfWork.ReviewRepository.GetAllAsync(
            predicate: r => r.Book.NormalizationName == request.BookUrlName,
            tracking: false,
            "Book");
        return _mapper.Map<IEnumerable<GetAllReviewQueryResponse>>(reviews);
    }
}
