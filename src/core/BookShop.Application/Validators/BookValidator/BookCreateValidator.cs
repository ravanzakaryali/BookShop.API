using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.CQRS.Commands.Request.BookRequest;
using BookShop.Application.Extensions;
using FluentValidation;

namespace BookShop.Application.Validators.BookValidator;

public class BookCreateValidator : AbstractValidator<BookCreateRequest>
{
    private readonly IValidation _validation;

    public BookCreateValidator(IValidation validation)
    {
        _validation = validation;
        RuleFor(c => c.Files)
            .FilesSize(5120).WithMessage($"File size must be {5120}kb")
            .FilesType("image").WithMessage($"File type must be image");
        
        RuleFor(c => c.Price).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
        RuleFor(c => c.Description).NotNull().NotEmpty();
        RuleFor(c => c.Name).Must(_validation.Unique<Book>).MaximumLength(128);
        RuleFor(c => c.ImageMainTh).GreaterThan(0).LessThanOrEqualTo(c=>c.Files.Count);
    }
    
}
