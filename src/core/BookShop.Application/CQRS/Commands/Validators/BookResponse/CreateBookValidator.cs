using BookShop.Application.CQRS.Commands.Request.BookRequest;
using BookShop.Application.Extensions.FormFileExtensions;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace BookShop.Application.CQRS.Commands.Validators.BookResponse;

public class CreateBookValidator : AbstractValidator<CreateBookRequest>
{
	public CreateBookValidator()
	{
		RuleFor(c => c.Files).Must(CheckFile);
		RuleFor(c=>c.Price).NotEmpty().NotNull().GreaterThan(0);
		RuleFor(c => c.Description).NotNull().NotEmpty();
		RuleFor(c => c.Title).MaximumLength(128);
	}
	public bool CheckFile(IFormFileCollection formFiles)
	{
		return formFiles.ToList().Any(f => f.CheckSize(5120) && f.CheckType("image"));
	}
}
