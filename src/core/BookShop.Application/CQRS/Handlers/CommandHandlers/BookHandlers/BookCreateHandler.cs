using BookShop.Application.Asbtarcts.Services.Storage;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.BookResponse;
using BookShop.Application.CQRS.Commands.Request.BookRequest;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BookHandlers;

public class BookCreateHandler : IRequestHandler<BookCreateRequest, BookCreateResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStorageService _storageService;

    public BookCreateHandler(IMapper mapper, IUnitOfWork unitOfWork, IStorageService storageService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _storageService = storageService;
    }

    public async Task<BookCreateResponse> Handle(BookCreateRequest request, CancellationToken cancellationToken)
    {
        Book book = _mapper.Map<Book>(request);
        List<FileUploadResponse> response =
               await _storageService.UploadAsync(request.Files, "bookShop", "Username"); //Todo: login olan username olacaq
        List<BookImage> bookImages = new();
        int count = book.BookImages.Count + request.ImageMainTh;
        for (int i = 0; i < response.Count; i++)
        {
            bookImages.Add(new BookImage
            {
                IsMain = i == count,
                Storage = "Azure",
                Path = response[i].ContainerName,
                StorageUrl = "https://azureservicestorage.blob.core.windows.net/",
                Name = response[i].FileName
            });
        }
        book.BookImages = bookImages;
        await _unitOfWork.BookRepository.AddAsync(book);
        await _unitOfWork.SaveChangesAsync();
        return new BookCreateResponse();
    }
}
