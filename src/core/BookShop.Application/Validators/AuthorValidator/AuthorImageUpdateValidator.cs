using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using BookShop.Application.Extensions;
using FluentValidation;

namespace BookShop.Application.Validators.AuthorValidator;

public class AuthorImageUpdateValidator : AbstractValidator<AuthorImageUpdateRequest>
{
    private readonly IValidation _validation;

    public AuthorImageUpdateValidator(IValidation validation)
    {
        _validation = validation;
        RuleFor(a => a.Image)
            .FileSize(5120).WithMessage($"File size must be {5120}kb")
            .FileType("image").WithMessage($"File type must be image");
    }
}
