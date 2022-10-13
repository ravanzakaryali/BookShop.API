using AutoMapper;
using BookShop.Application.Asbtarcts.Services.Storage;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.BookResponse;
using BookShop.Application.CQRS.Commands.Request.BookRequest;
using BookShop.Application.DTOs.FileDto;
using BookShop.Domain.Entities;
using MediatR;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.BookCommand;

public class CreateBookHandler : IRequestHandler<CreateBookRequest, CreateBookResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStorageService _storageService;

    public CreateBookHandler(IMapper mapper, IUnitOfWork unitOfWork, IStorageService storageService)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _storageService = storageService;
    }

    public async Task<CreateBookResponse> Handle(CreateBookRequest request, CancellationToken cancellationToken)
    {
        Book book = _mapper.Map<Book>(request);
        List<FileUploadResponse> response =
               await _storageService.UploadAsync(request.Files, "bookShop", "User name"); //Todo: login olan username olacaq
        List<BookImage> bookImages = new();
        response.ForEach(r =>
        {
            bookImages.Add(new BookImage
            {
                Storage = "Azure",
                Path = r.ContainerName,
                Name = r.FileName
            });
        });
        book.BookImages = bookImages;
        await _unitOfWork.BookRepository.AddAsync(book);
        await _unitOfWork.SaveChangesAsync();
        return new CreateBookResponse();
    }
}
