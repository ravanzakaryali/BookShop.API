using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.BookRequest;
using BookShop.Application.CQRS.Queries.Response.BookResponse;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.BookHandler;

internal class GetBookQueryHandler : IRequestHandler<GetBookQueryRequest, GetBookQueryResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBookQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetBookQueryResponse> Handle(GetBookQueryRequest request, CancellationToken cancellationToken)
    {
        Book? book = await _unitOfWork.BookRepository.GetAsync(
            b => b.NormalizationName == request.BookUrlName,
            tracking: true,
            "BookPrices",
            nameof(Vendor),
            nameof(Category),
            nameof(E.Type),
            "Formats",
            "Languages",
            "BookImages");

        if (book is null) throw new Exception("Book not found"); // Todo: Book Exception

        List<ImageGetDto> images = new();
        GetBookQueryResponse response = _mapper.Map<GetBookQueryResponse>(book);

        book.BookImages.ToList().ForEach(i =>
        {
            images.Add(new ImageGetDto
            {
                ImageUrl = i.StorageUrl + i.Name 
            });
        });
        response.BookImages = images;
        return response;
    }
}
