using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.AuthorRequest;
using BookShop.Application.CQRS.Queries.Response.AuthorResponse;
using BookShop.Application.DTOs;
using BookShop.Application.Exceptions;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.AuthorHandler;

public class AuthorGetHandler : IRequestHandler<AuthorGetRequest, AuthorGetResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuthorGetHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AuthorGetResponse> Handle(AuthorGetRequest request, CancellationToken cancellationToken)
    {
        Author? author = await _unitOfWork.AuthorRepository.GetAsync(a => a.Id == request.AuthorId, false, nameof(AuthorImage), "Awards");
        if (author is null) throw new EntityNotFoundException<Author, string>(request.AuthorId);

        AuthorGetResponse response = _mapper.Map<AuthorGetResponse>(author);
        response.AuthorName = author.NormalizationName;
        response.AuthorImage = new ImageGetDto
        {
            Id = author.AuthorImageId,
            ImageUrl = author.AuthorImage.StorageUrl + author.AuthorImage.Name,
            IsMain = true
        };
        return response;
    }
}
