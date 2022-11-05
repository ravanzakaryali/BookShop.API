using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.CQRS.Commands.Request.BookRequest;
using BookShop.Application.Extensions.FormFileExtensions;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.Validators.BookValidator;

public class CreateBookValidator : AbstractValidator<BookCreateRequest>
{
    private readonly IValidation _validation;

    public CreateBookValidator(IValidation validation)
    {
        _validation = validation;
        RuleFor(c => c.Files).Must(_validation.CheckFile);
        RuleFor(c => c.Price).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(c => c.Description).NotNull().NotEmpty();
        RuleFor(c => c.Name).MaximumLength(128);
    }
}
