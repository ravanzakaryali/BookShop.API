using BookShop.Application.Asbtarcts.Services.Storage;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.BlogResponse;
using BookShop.Application.CQRS.Commands.Request.BlogRequest;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BlogHandlers;

internal class BlogCreateHandler : IRequestHandler<BlogCreateRequest, BlogCreateResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStorageService _storageService;

    public BlogCreateHandler(IUnitOfWork unitOfWork, IMapper mapper, IStorageService storageService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _storageService = storageService;
    }

    public async Task<BlogCreateResponse> Handle(BlogCreateRequest request, CancellationToken cancellationToken)
    {
        if (request.Images.Count < request.ImageMainTh) throw new Exception("Nt çox oldu"); //Todo: Exception
        Blog blog = _mapper.Map<Blog>(request);
        List<FileUploadResponse> response =
               await _storageService.UploadAsync(request.Images, "bookShop", "blog");
        List<BlogImage> blogImages = new();
        int count = blog.BlogImages.Count + request.ImageMainTh;
        for (int i = 0; i < response.Count; i++)
        {
            blogImages.Add(new BlogImage
            {
                IsMain = i == count,
                Storage = "Azure",
                Path = response[i].ContainerName,
                StorageUrl = "https://azureservicestorage.blob.core.windows.net/",
                Name = response[i].FileName
            });
        }
        blog.BlogImages = blogImages;
        await _unitOfWork.BlogRepository.AddAsync(blog);
        await _unitOfWork.SaveChangesAsync();
        return new BlogCreateResponse();
    }
}
