using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Application.CQRS.Commands.Request.BookRequest;
using FluentValidation;

namespace BookShop.Application.Validators.BookValidator;

public class BookUpdateValidator : AbstractValidator<BookUpdateRequest>
{
    private readonly IValidation _validation;

    public BookUpdateValidator(IValidation validation)
    {
        _validation = validation;
        RuleFor(c => c.BookDto.Name).Must(_validation.Unique<Book>).MaximumLength(128);
        RuleFor(c => c.BookDto.Price).NotNull().GreaterThan(0);
        RuleFor(c => c.BookDto.Description).NotNull().NotEmpty();
        RuleFor(c=>c.BookDto.CategoryId).NotEmpty();
    }
}
