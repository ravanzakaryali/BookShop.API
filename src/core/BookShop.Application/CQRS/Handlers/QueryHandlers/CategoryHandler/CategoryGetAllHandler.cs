using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.CategoryRequest;
using BookShop.Application.CQRS.Queries.Response.CategoryResponse;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.CategoryHandler;

public class CategoryGetAllHandler : IRequestHandler<CategoryGetAllRequest, IEnumerable<CategoryGetAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryGetAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryGetAllResponse>> Handle(CategoryGetAllRequest request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<CategoryGetAllResponse>>(await _unitOfWork.CategoryRepository.GetAllAsync(request.Page, request.Size, c => c.Name, includes: "SubCategories"));
    }
}
