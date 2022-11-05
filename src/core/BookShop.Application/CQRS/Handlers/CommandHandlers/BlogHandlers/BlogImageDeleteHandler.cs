using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.BookResponse;
using BookShop.Application.CQRS.Commands.Request.BlogRequest;
using BookShop.Application.CQRS.Commands.Request.BookRequest;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BlogHandlers;

internal class BlogImageDeleteHandler : IRequestHandler<BlogImageDeleteRequest, BlogImageDeleteResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public BlogImageDeleteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BlogImageDeleteResponse> Handle(BlogImageDeleteRequest request, CancellationToken cancellationToken)
    {
        Blog? blog = await _unitOfWork.BlogRepository.GetAsync(b => b.NormalizationName == request.BlogName, includes: "BlogImages");
        if (blog is null) throw new Exception(); //Todo: Blog exception
        BlogImage? blogImage = blog.BlogImages.FirstOrDefault(i => i.Id == request.ImageId);
        if (blogImage is null) throw new Exception(); //Todo: BlogImage exception
        blog.BlogImages.Remove(blogImage);
        await _unitOfWork.SaveChangesAsync();
        return new BlogImageDeleteResponse();
    }
}
