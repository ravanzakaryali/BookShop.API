using BookShop.Application.CQRS.Commands.Request.AuthorRequest;
using BookShop.Application.Test.TestData.EntitiesData;
using BookShop.Application.Validators.AuthorValidator;
using BookShop.Domain.Entities;
using FluentValidation.TestHelper;
using BookShop.Application.Test.Services;


namespace BookShop.Application.Test.Validators;

public class AuhtorValidatorsTest : AuhtorData
{
    private readonly EntityService<Author> _baseServices;
    public AuhtorValidatorsTest()
    {
        _baseServices = new EntityService<Author>();
    }

    [Theory, MemberData(nameof(AuthorCreateRequest))]
    public async Task AuhtorCreateValidation_AuthorCreateRequest_ReturnError(AuthorCreateRequest authorCreateRequest)
    {
        AuthorCreateValidator validation = new(_baseServices.GetValidation());
        TestValidationResult<AuthorCreateRequest> result = await validation.TestValidateAsync(authorCreateRequest);
        result.ShouldHaveAnyValidationError();
    }

    [Theory,MemberData(nameof(AuthorUpdateRequest))]
    public async Task AuthorUpdateValidation_AuthorUpdateRequest_ReturnError(AuthorUpdateRequest authorUpdateRequest)
    {
        AuthorUpdateValidator validation = new(_baseServices.GetValidation());
        TestValidationResult<AuthorUpdateRequest> result = await validation.TestValidateAsync(authorUpdateRequest);
        result.ShouldHaveAnyValidationError();
    }

    [Theory,MemberData(nameof(AuthorImageUpdateRequest))]   
    public async Task AuthorImageUpdateValidation_AuthorImageUpdateRequest_ReturnError(AuthorImageUpdateRequest authorImageUpdateRequest)
    {
        AuthorImageUpdateValidator validation = new(_baseServices.GetValidation());
        TestValidationResult<AuthorImageUpdateRequest> result = await validation.TestValidateAsync(authorImageUpdateRequest);
        result.ShouldHaveAnyValidationError();
    }
}
