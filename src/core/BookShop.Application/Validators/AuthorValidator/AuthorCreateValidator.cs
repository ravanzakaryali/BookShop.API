using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using BookShop.Application.Extensions;
using FluentValidation;

namespace BookShop.Application.Validators.AuthorValidator;

public class AuthorCreateValidator : AbstractValidator<AuthorCreateRequest>
{
	private readonly IValidation _validation;

	public AuthorCreateValidator(IValidation validation)
	{
		_validation = validation;
		RuleFor(a => a.Name)
			.NotEmpty()
			.NotNull()
			.MaximumLength(64)
			.Must(_validation.Unique<Author>)
			.WithMessage("Already name");
		RuleFor(a => a.Description).NotNull().NotEmpty().MinimumLength(16).MaximumLength(256);
		RuleFor(a => a.ProfileImage)
			.FileSize(5120).WithMessage($"File size must be {5120}")
            .FileType("image").WithMessage($"File size must be image");
    }
}
