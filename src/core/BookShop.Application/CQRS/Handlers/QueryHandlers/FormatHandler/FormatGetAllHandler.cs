using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.FormatRequest;
using BookShop.Application.CQRS.Queries.Response.FormatResponse;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.FormatHandler;

public class FormatGetAllHandler : IRequestHandler<FormatGetAllRequest, IEnumerable<FormatGetAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public FormatGetAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<FormatGetAllResponse>> Handle(FormatGetAllRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<FormatGetAllResponse>>(await _unitOfWork.FormatRepository.GetAllAsync(request.Page, request.Size, f => f.Name));
    }
}
