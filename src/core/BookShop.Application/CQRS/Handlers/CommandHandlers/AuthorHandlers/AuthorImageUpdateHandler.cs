using BookShop.Application.Asbtarcts.Services.Storage;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.AuthorResponse;
using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.AuthorHandlers;

internal class AuthorImageUpdateHandler : IRequestHandler<AuthorImageUpdateRequest, AuthorImageUpdateResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStorageService _storageService;

    public AuthorImageUpdateHandler(IUnitOfWork unitOfWork, IStorageService storageService)
    {
        _unitOfWork = unitOfWork;
        _storageService = storageService;
    }

    public async Task<AuthorImageUpdateResponse> Handle(AuthorImageUpdateRequest request, CancellationToken cancellationToken)
    {
        Author? author = await _unitOfWork.AuthorRepository.GetAsync(r => r.Id == request.AuthorId, includes: "AuhorImage");
        if (author is null) throw new Exception();//Todo: Exception
        if (author.AuthorImage.Id == request.ImageId) throw new Exception(); //Todo: Exception
        FileUploadResponse file = await _storageService.UploadAsync(request.Image, "bookShop", "author");    
        author.AuthorImage = new AuthorImage
        {
            Name = file.FileName,
            StorageUrl = "https://azureservicestorage.blob.core.windows.net/",
            Path = "bookShop",
            Storage = "Azure"
        };
        await _unitOfWork.SaveChangesAsync();
        return new AuthorImageUpdateResponse();
    }
}
