using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using BookShop.Application.Extensions.FormFileExtensions;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.Validators.AuthorValidator;

public class AuthorImageUpdateValidator : AbstractValidator<AuthorImageUpdateRequest>
{
	private readonly IValidation _validation;

	public AuthorImageUpdateValidator(IValidation validation)
	{
		_validation = validation;
		RuleFor(a => a.Image).Must(_validation.CheckFile);
	}
}
