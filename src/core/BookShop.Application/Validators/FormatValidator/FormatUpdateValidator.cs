using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.CQRS.Commands.Request.FormatRequest;
using FluentValidation;

namespace BookShop.Application.Validators.FormatValidator;

internal class FormatUpdateValidator : AbstractValidator<FormatUpdateRequest>
{
    private readonly IValidation _validation;
    public FormatUpdateValidator(IValidation validation)
    {
        _validation = validation;
        RuleFor(f => f.Format.Name).MustAsync(_validation.UniqueAsync<Format>).NotNull().NotEmpty().MinimumLength(2).MaximumLength(64);
    }
}
