﻿using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.CQRS.Commands.Request.CategoryRequest;
using FluentValidation;

namespace BookShop.Application.Validators.CategoryValidator;

internal class SubCategoryCreateValidator : AbstractValidator<SubCategoryCreateRequest>
{
    private readonly IValidation _validation;
    public SubCategoryCreateValidator(IValidation validation)
    {
        _validation = validation;
        RuleFor(sc => sc.Category.Name).NotNull().NotEmpty().MaximumLength(32).MustAsync(_validation.UniqueAsync<Category>);
    }
}