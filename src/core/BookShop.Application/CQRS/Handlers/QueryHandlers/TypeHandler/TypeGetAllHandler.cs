using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.TypeRequest;
using BookShop.Application.CQRS.Queries.Response.TypeResponse;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.TypeHandler;

public class TypeGetAllHandler : IRequestHandler<TypeGetAllRequest, IEnumerable<TypeGetAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TypeGetAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TypeGetAllResponse>> Handle(TypeGetAllRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<IEnumerable<TypeGetAllResponse>>(await _unitOfWork.TypeRepository.GetAllAsync(request.Page, request.Size, t => t.Name));
    }
}
