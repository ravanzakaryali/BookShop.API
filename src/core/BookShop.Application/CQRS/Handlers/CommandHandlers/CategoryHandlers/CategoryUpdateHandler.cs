using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.CategoryResponse;
using BookShop.Application.CQRS.Commands.Request.CategoryRequest;
using BookShop.Application.Extensions;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.CategoryHandlers;

public class CategoryUpdateHandler : IRequestHandler<CategoryUpdateRequest, CategoryUpdateResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryUpdateHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<CategoryUpdateResponse> Handle(CategoryUpdateRequest request, CancellationToken cancellationToken)
    {
        Category? category = await _unitOfWork.CategoryRepository.GetAsync(request.Id);
        if (category is null) throw new Exception("Category not found"); //Todo: Category not found
        if (_unitOfWork.CategoryRepository
            .GetAsync(c => c.NormalizationName == request.Category.Name.CharacterRegulatory(int.MaxValue)) != null)
            throw new Exception("Already"); //Todo: Already Exception
        category.Name = request.Category.Name;
        await _unitOfWork.SaveChangesAsync();
        return new CategoryUpdateResponse();

    }
}
