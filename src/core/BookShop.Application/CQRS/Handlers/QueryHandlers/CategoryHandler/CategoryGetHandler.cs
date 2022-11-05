using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Queries.Request.CategoryRequest;
using BookShop.Application.CQRS.Queries.Response.CategoryResponse;

namespace BookShop.Application.CQRS.Handlers.QueryHandlers.CategoryHandler;

public class CategoryGetHandler : IRequestHandler<CategoryGetRequest, CategoryGetResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryGetHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CategoryGetResponse> Handle(CategoryGetRequest request, CancellationToken cancellationToken)
    {
        Category? category = await _unitOfWork.CategoryRepository.GetAsync(request.Id);
        if (category is null) throw new Exception("Category not found"); //Todo: Exception category
        return _mapper.Map<CategoryGetResponse>(category);
    }
}
