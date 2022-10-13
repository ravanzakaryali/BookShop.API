using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.BlogRequest;
using BookShop.Application.CQRS.Queries.Response.BlogReponse;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.BlogHandler;

public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQueryRequest, IEnumerable<GetAllBlogsResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllBlogsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllBlogsResponse>> Handle(GetAllBlogsQueryRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Blog> blogs = await _unitOfWork.BlogRepository.GetAllAsync(
             page: request.Page,
             size: request.Size,
             g => g.Title,
             tracking: false,
             includes: nameof(BlogerUser));
        List<GetAllBlogsResponse> responses = new();
        IEnumerable<string> bookImages = blogs.SelectMany(b => b.BlogImages).Where(b => b.IsMain == true).Select(b => b.Name);
        blogs.ToList().ForEach(b =>
        {
            BlogImage? bookImage = b.BlogImages.FirstOrDefault(b => b.IsMain == true);
            GetAllBlogsResponse response = _mapper.Map<GetAllBlogsResponse>(b);
            if (bookImage != null)
            {
                response.ImageUrl = bookImage.Path + bookImage.Name;
            }
            responses.Add(response);
        });
        return responses;
    }
}
