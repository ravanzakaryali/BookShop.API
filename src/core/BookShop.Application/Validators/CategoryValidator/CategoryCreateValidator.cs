using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.CQRS.Commands.Request.CategoryRequest;
using FluentValidation;

namespace BookShop.Application.Validators.CategoryValidator;

public class CategoryCreateValidator : AbstractValidator<CategoryCreateRequest>
{
    private readonly IValidation _validation;

    public CategoryCreateValidator(IValidation validation)
    {
        _validation = validation;
        RuleFor(c => c.Name).NotEmpty().NotNull().MaximumLength(32).MustAsync(_validation.UniqueAsync<Category>);
    }
}