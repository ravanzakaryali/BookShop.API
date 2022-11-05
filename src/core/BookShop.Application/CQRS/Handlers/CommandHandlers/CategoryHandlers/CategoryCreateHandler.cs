using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.CategoryResponse;
using BookShop.Application.CQRS.Commands.Request.CategoryRequest;
using BookShop.Application.Extensions;
using BookShop.Domain.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.CategoryHandlers;

public class CategoryCreateHandler : IRequestHandler<CategoryCreateRequest, CategoryCreateResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public CategoryCreateHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<CategoryCreateResponse> Handle(CategoryCreateRequest request, CancellationToken cancellationToken)
    {
        if(_unitOfWork.CategoryRepository.GetAsync(c=>c.NormalizationName == request.Name.CharacterRegulatory(int.MaxValue)) != null)
        {
            throw new Exception("Already"); //Todo: Already Exception
        }
        Category category = await _unitOfWork.CategoryRepository.AddAsync(new Category
        {
            Name = request.Name,
        });
        await _unitOfWork.SaveChangesAsync();
        return new CategoryCreateResponse(category.Id);
    }
}
