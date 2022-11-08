using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using FluentValidation;

namespace BookShop.Application.Validators.AuthorValidator;

public class AuthorUpdateValidator : AbstractValidator<AuthorUpdateRequest>
{
    private readonly IValidation _validation;
	public AuthorUpdateValidator(IValidation validation)
	{
		_validation = validation;
		RuleFor(a => a.Author.Name)
			.MaximumLength(64)
			.Must(_validation.Unique<Author>);
        RuleFor(a => a.Author.Description).MinimumLength(16).MaximumLength(256);

    }
}
