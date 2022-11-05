using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.BlogResponse;
using BookShop.Application.CQRS.Commands.Reponse.BookResponse;
using BookShop.Application.CQRS.Commands.Request.BlogRequest;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BlogHandlers;

internal class BlogDeleteHandler : IRequestHandler<BlogDeleteRequest, BlogDeleteResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public BlogDeleteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BlogDeleteResponse> Handle(BlogDeleteRequest request, CancellationToken cancellationToken)
    {
        Blog? blog = await _unitOfWork.BlogRepository.GetAsync(p => p.NormalizationName == request.BlogName.Trim().ToLower());
        if (blog is null) throw new Exception("Blog not found"); //Todo: Exception
        _unitOfWork.BlogRepository.Remove(blog);
        await _unitOfWork.SaveChangesAsync();
        return new BlogDeleteResponse(blog.NormalizationName);
    }
}
