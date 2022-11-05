using BookShop.Application.Asbtarcts.Services.Storage;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.AuthorResponse;
using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using BookShop.Application.DTOs;
using BookShop.Application.Extensions;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.AuthorHandlers;

internal class AuthorCreateHandler : IRequestHandler<AuthorCreateRequest, AuthorCreateResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStorageService _storageService;
    private readonly IMapper _mapper;

    public AuthorCreateHandler(IUnitOfWork unitOfWork, IStorageService storageService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _storageService = storageService;
        _mapper = mapper;
    }

    public async Task<AuthorCreateResponse> Handle(AuthorCreateRequest request, CancellationToken cancellationToken)
    {
        Author author = _mapper.Map<Author>(request);
        FileUploadResponse response = await _storageService.UploadAsync(request.ProfileImage, "bookShop", "author");
        author.AuthorImage = new AuthorImage
        {
            Name = response.FileName,
            StorageUrl = "https://azureservicestorage.blob.core.windows.net/",
            Path = "bookShop",
            Storage = "Azure"
        };
        return new AuthorCreateResponse();  
    }
}
