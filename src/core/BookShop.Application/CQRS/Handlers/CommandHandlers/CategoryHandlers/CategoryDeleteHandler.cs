﻿using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Reponse.CategoryResponse;
using BookShop.Application.CQRS.Commands.Request.CategoryRequest;
using BookShop.Application.Exceptions;

namespace BookShop.Application.CQRS.Handlers.CommandHandlers.CategoryHandlers;

public class CategoryDeleteHandler : IRequestHandler<CategoryDeleteRequest, CategoryDeleteResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryDeleteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoryDeleteResponse> Handle(CategoryDeleteRequest request, CancellationToken cancellationToken)
    {
        Category? category = await _unitOfWork.CategoryRepository.GetAsync(request.Id);
        if (category is null) throw new EntityNotFoundException<Category,string>(request.Id);
        Category deleteCategory = _unitOfWork.CategoryRepository.Remove(category);
        await _unitOfWork.SaveChangesAsync();
        return new CategoryDeleteResponse(deleteCategory.Id);
    }
}
