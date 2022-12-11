using BookShop.Application.Asbtarcts.Services.Storage;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.AuthorResponse;
using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using BookShop.Application.DTOs;
using BookShop.Application.Exceptions;
using static System.Net.WebRequestMethods;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.AuthorHandlers;

internal class AuthorUpdateHandler : IRequestHandler<AuthorUpdateRequest, AuthorUpdateResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStorageService _storageService;
    private readonly IMapper _mapper;

    public AuthorUpdateHandler(IUnitOfWork unitOfWork, IStorageService storageService, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _storageService = storageService;
        _mapper = mapper;
    }

    public async Task<AuthorUpdateResponse> Handle(AuthorUpdateRequest request, CancellationToken cancellationToken)
    {
        Author? author = await _unitOfWork.AuthorRepository.GetAsync(a=>a.Id == request.Id,tracking: false);
        if (author is null) throw new EntityNotFoundException<Author, string>(request.Id);
        Author updateAuthor = _mapper.Map<Author>(request.Author);
        updateAuthor.Id = author.Id;
        _unitOfWork.AuthorRepository.Update(updateAuthor);
        await _unitOfWork.SaveChangesAsync();
        return new AuthorUpdateResponse();
    }
}
