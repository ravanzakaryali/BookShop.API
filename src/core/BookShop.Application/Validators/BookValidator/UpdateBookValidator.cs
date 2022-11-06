using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Request.BookRequest;
using FluentValidation;

namespace BookShop.Application.Validators.BookValidator;

public class UpdateBookValidator : AbstractValidator<BookUpdateRequest>
{
    private readonly IValidation _validation;

    public UpdateBookValidator(IValidation validation)
    {
        _validation = validation;
        RuleFor(c => c.BookDto.Name).Must(_validation.Unique<Book>).MaximumLength(128);
        RuleFor(c => c.BookDto.Price).NotEmpty().NotNull().GreaterThan(0);
        RuleFor(c => c.BookDto.Description).NotNull().NotEmpty();
    }
}
