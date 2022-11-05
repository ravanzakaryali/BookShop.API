using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.AuthorRequest;
using BookShop.Application.CQRS.Queries.Response.AuthorResponse;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.AuthorHandler;

public class AuthorGetAllHandler : IRequestHandler<AuthorGetAllRequest, IEnumerable<AuthorGetAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuthorGetAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorGetAllResponse>> Handle(AuthorGetAllRequest request, CancellationToken cancellationToken)
    {
        List<Author> authors = await _unitOfWork.AuthorRepository.GetAllAsync(request.Page, request.Size, a => a.Name, includes: nameof(AuthorImage));
        List<AuthorGetAllResponse> response = new();
        authors.ForEach(a => response.Add(new AuthorGetAllResponse
        {
            Name = a.Name,
            AuthorName = a.NormalizationName,
            AuthorImage = new ImageGetDto
            {
                Id = a.AuthorImageId,
                ImageUrl = a.AuthorImage.StorageUrl + a.AuthorImage.Name ,
                IsMain = true
            }
        }));
        return response; 
    }
}
