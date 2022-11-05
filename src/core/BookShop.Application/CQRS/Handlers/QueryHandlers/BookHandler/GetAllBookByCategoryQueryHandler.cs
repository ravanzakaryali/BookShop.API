using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.BookRequest;
using BookShop.Application.CQRS.Queries.Response.BookResponse;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.BookHandler;

internal class GetAllBookByCategoryQueryHandler : IRequestHandler<GetAllBooksByCategoryRequest, List<GetAllBookQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllBookByCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<GetAllBookQueryResponse>> Handle(GetAllBooksByCategoryRequest request, CancellationToken cancellationToken)
    {
        List<Book> books = await _unitOfWork.BookRepository.GetAllAsync(
            request.Page,
            request.Size,
            predicate: b => b.NormalizationName == request.categoryName,
            orderBy: r => r.Name,
            includes: "BookImages");

        List<GetAllBookQueryResponse> listResponse = new();
        var bookImages = books.SelectMany(b => b.BookImages).Where(b => b.IsMain == true).Select(b => b.Name);

        books.ForEach(b =>
        {
            BookImage? bookImage = b.BookImages.FirstOrDefault(b => b.IsMain == true);
            GetAllBookQueryResponse response = _mapper.Map<GetAllBookQueryResponse>(b);
            if (bookImage != null)
            {
                response.ImageUrl = bookImage.StorageUrl + bookImage.Name;
            }
            listResponse.Add(response);
        });
        return listResponse;
    }
}
