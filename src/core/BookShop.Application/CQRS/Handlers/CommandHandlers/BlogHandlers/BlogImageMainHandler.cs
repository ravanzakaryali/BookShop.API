using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.BlogResponse;
using BookShop.Application.CQRS.Commands.Request.BlogRequest;
using BookShop.Application.Extensions;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BlogHandlers;

internal class BlogImageMainHandler : IRequestHandler<BlogImageMainRequest, BlogImageMainResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public BlogImageMainHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BlogImageMainResponse> Handle(BlogImageMainRequest request, CancellationToken cancellationToken)
    {
        Blog? blog = await _unitOfWork.BlogRepository.GetAsync(r => r.NormalizationName == request.BlogName, includes: "BlogImages");
        if (blog is null) throw new Exception();//Todo: Blog exception
        blog.BlogImages.ToList().ForEach(i => i.IsMain = false);
        BlogImage? blogImage = blog.BlogImages.FirstOrDefault(b => b.Id == request.ImageId);
        if (blogImage is null) throw new Exception(); //Todo: BlogImage exception
        blogImage.IsMain = true;
        await _unitOfWork.SaveChangesAsync();
        return new BlogImageMainResponse();

    }
}
