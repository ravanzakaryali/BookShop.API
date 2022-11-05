using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.BlogResponse;
using BookShop.Application.CQRS.Commands.Request.BlogRequest;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BlogHandlers;

internal class BlogUpdateHandler : IRequestHandler<BlogUpdateRequest, BlogUpdateResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BlogUpdateHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BlogUpdateResponse> Handle(BlogUpdateRequest request, CancellationToken cancellationToken)
    {
        Blog? blog = await _unitOfWork.BlogRepository.GetAsync(b => b.NormalizationName == request.BlogName, tracking: false);
        if (blog is null) throw new Exception("Blog Not found");
        Blog newBlog = _mapper.Map<Blog>(request.Blog);
        newBlog.Id = blog.Id;
        _unitOfWork.BlogRepository.Update(newBlog);
        await _unitOfWork.SaveChangesAsync();
        return new BlogUpdateResponse();
    }
}
