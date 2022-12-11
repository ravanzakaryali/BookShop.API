using BookShop.Application.Asbtarcts.Services.Storage;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.BookResponse;
using BookShop.Application.CQRS.Commands.Request.BookRequest;
using BookShop.Application.DTOs;
using BookShop.Application.Exceptions;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BookHandlers;

public class BookImageUploadHandler : IRequestHandler<BookImageUploadRequest, IEnumerable<BookImageUploadResponse>>
{

    private readonly IStorageService _storageService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookImageUploadHandler(IStorageService storageService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _storageService = storageService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookImageUploadResponse>> Handle(BookImageUploadRequest request, CancellationToken cancellationToken)
    {
        if (request.Images.Count < request.ImageIsMainTh) throw new Exception("Nt çox oldu"); //TODO: Exception

        Book? book = await _unitOfWork.BookRepository.GetAsync(b => b.NormalizationName == request.BookName.ToLower().Trim(), includes: "BlogImages");
        if (book is null) throw new EntityNotFoundException<Book,string>(request.BookName);

        List<FileUploadResponse> response =
               await _storageService.UploadAsync(request.Images, "bookshop", "book");

        int count = book.BookImages.Count + 1; 
        
        book.BookImages.ElementAt(count + request.ImageIsMainTh)!.IsMain = true;

        List<BookImage> bookImages = new();

        response.ForEach(r => book.BookImages.Add(new BookImage
        {
            IsMain = false,
            CreatedBy = "Username", //TODO: Username,
            Name = r.FileName,
            Path = r.ContainerName,
            Storage = "Azure",
            StorageUrl = "https://azureservicestorage.blob.core.windows.net/"
        }));

        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<IEnumerable<BookImageUploadResponse>>(book.BookImages);
    }
}
