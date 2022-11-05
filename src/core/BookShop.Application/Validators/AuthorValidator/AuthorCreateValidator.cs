﻿using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using FluentValidation;

namespace BookShop.Application.Validators.AuthorValidator;

public class AuthorCreateValidator : AbstractValidator<AuthorCreateRequest>
{
	private readonly IValidation _validation;

	public AuthorCreateValidator(IValidation validation)
	{
		_validation = validation;
		RuleFor(a => a.Name).NotEmpty().NotNull().MaximumLength(64).MustAsync(_validation.UniqueAsync<Author>);
		RuleFor(a => a.Description).NotNull().NotEmpty().MinimumLength(16).MaximumLength(256);
		RuleFor(a => a.ProfileImage).Must(_validation!.CheckFile);
	}
}