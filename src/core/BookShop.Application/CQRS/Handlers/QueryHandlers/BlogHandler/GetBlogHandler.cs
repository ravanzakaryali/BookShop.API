using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.BlogRequest;
using BookShop.Application.CQRS.Queries.Response.BlogReponse;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.BlogHandler;

public class GetBlogHandler : IRequestHandler<GetBlogRequest, GetBlogResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBlogHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetBlogResponse> Handle(GetBlogRequest request, CancellationToken cancellationToken)
    {
        Blog? blog = await _unitOfWork.BlogRepository.GetAsync(b => b.NormalizationName == request.BookName.ToLower(),includes: "BlogImages");
        if (blog is null) throw new Exception(); //Todo: Blog exception

        GetBlogResponse response = _mapper.Map<GetBlogResponse>(blog);
        List<ImageGetDto> blogImages = new();

        blog.BlogImages.ToList().ForEach(i =>
        {
            blogImages.Add(new ImageGetDto
            {
                Id = i.Id,
                ImageUrl = i.StorageUrl + i.Name,
                IsMain = i.IsMain
            });
        });
        response.BlogImages = blogImages;
        return response;
    }
}
