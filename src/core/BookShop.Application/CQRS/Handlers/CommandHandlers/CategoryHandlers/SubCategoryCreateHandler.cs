using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.CategoryResponse;
using BookShop.Application.CQRS.Commands.Request.CategoryRequest;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.CategoryHandlers;

public class SubCategoryCreateHandler : IRequestHandler<SubCategoryCreateRequest, SubCategoryCreateResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public SubCategoryCreateHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
        
    public async Task<SubCategoryCreateResponse> Handle(SubCategoryCreateRequest request, CancellationToken cancellationToken)
    {
        Category? category = await _unitOfWork.CategoryRepository.GetAsync(request.CategoryId);
        if (category is null) throw new Exception("Category not found"); //Todo: Exception
        Category newCategory = await _unitOfWork.CategoryRepository.AddAsync(new Category
        {
            Name = request.Category.Name
        });
        category.SubCategories.Add(newCategory);
        await _unitOfWork.SaveChangesAsync();
        return new SubCategoryCreateResponse(request.CategoryId, newCategory.Id);

    }
}
