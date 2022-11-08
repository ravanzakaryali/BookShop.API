using BookShop.Application.CQRS.Commands.Request.BookRequest;
using BookShop.Application.Test.Services;
using BookShop.Application.Test.TestData.EntitiesData;
using BookShop.Application.Validators.BookValidator;
using BookShop.Domain.Entities;
using FluentValidation.TestHelper;

namespace BookShop.Application.Test.Validators;

public class BookValidatorsTest : BookData
{
    private readonly EntityService<Book> _baseServices;
    public BookValidatorsTest()
    {
        _baseServices = new();
    }
    [Theory, MemberData(nameof(BookCreateRequests))]
    public async Task BookCreateValidation_BookCreateRequest_ReturnError(BookCreateRequest bookCreateRequest)
    {
        BookCreateValidator validation = new(_baseServices.GetValidation());
        TestValidationResult<BookCreateRequest> result = await validation.TestValidateAsync(bookCreateRequest);
        result.ShouldHaveAnyValidationError();
    }
}
