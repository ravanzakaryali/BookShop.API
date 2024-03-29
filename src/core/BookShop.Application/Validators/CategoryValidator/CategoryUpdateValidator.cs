﻿using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.CQRS.Commands.Request.CategoryRequest;
using FluentValidation;

namespace BookShop.Application.Validators.CategoryValidator;

public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateRequest>
{

    private readonly IValidation _validation;
    public CategoryUpdateValidator(IValidation validation)
    {
        _validation = validation;
        RuleFor(c => c.Category.Name).NotNull().NotEmpty().MaximumLength(32).Must(_validation.Unique<Category>);
    }
}
