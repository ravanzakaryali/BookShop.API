using BookShop.Application.Asbtarcts.Services.Storage;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.BlogResponse;
using BookShop.Application.CQRS.Commands.Request.BlogRequest;
using BookShop.Application.DTOs;
using BookShop.Application.Exceptions;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BlogHandlers;

internal class BlogImageUploadHandler : IRequestHandler<BlogImageUploadRequest, IEnumerable<BlogImageUploadResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStorageService _storageService;
    private readonly IMapper _mapper;

    public BlogImageUploadHandler(IUnitOfWork unitOfWork, IStorageService storageService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _storageService = storageService;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BlogImageUploadResponse>> Handle(BlogImageUploadRequest request, CancellationToken cancellationToken)
    {
        if (request.Images.Count < request.ImageIsMainTh) throw new Exception("Nt çox oldu"); //TODO: Nt Exception
        Blog? blog = await _unitOfWork.BlogRepository.GetAsync(r => r.NormalizationName == request.BookName.ToLower().Trim(), includes: "BlogImages");
        if (blog is null) throw new EntityNotFoundException<Blog, string>(request.BookName);
        List<FileUploadResponse> response =
            await _storageService.UploadAsync(request.Images, "bookshop","blog");

        int count = blog.BlogImages.Count + 1;

        blog.BlogImages.ElementAt(count + request.ImageIsMainTh)!.IsMain = true;

        List<BlogImage> blogs = new();

        response.ForEach(r => blog.BlogImages.Add(new BlogImage
        {
            IsMain = false,
            CreatedBy = "Username", //TODO: Username,
            Name = r.FileName,
            Path = r.ContainerName,
            Storage = "Azure",
            StorageUrl = "https://azureservicestorage.blob.core.windows.net/"
        }));

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<IEnumerable<BlogImageUploadResponse>>(blog.BlogImages);
    }
}
