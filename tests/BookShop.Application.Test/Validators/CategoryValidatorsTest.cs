using BookShop.Application.CQRS.Commands.Request.CategoryRequest;
using BookShop.Application.Test.Services;
using BookShop.Application.Test.TestData.EntitiesData;
using BookShop.Application.Validators.CategoryValidator;
using BookShop.Domain.Entities;
using FluentValidation.TestHelper;

namespace BookShop.Application.Test.Validators;

public class CategoryValidatorsTest : CategoryData
{
    private readonly EntityService<Category> _baseServices;

    public CategoryValidatorsTest()
    {
        _baseServices = new EntityService<Category>();
    }

    [Theory,MemberData(nameof(CategoryCreateRequests))]
    public async Task CategoryCreateValidation_CategoryCreateRequest_ReturnError(CategoryCreateRequest categoryCreateRequest)
    {
        CategoryCreateValidator validation = new(_baseServices.GetValidation());
        TestValidationResult<CategoryCreateRequest> result = await validation.TestValidateAsync(categoryCreateRequest);
        result.ShouldHaveAnyValidationError();
    }
    [Theory,MemberData(nameof(CategoryUpdateRequests))]
    public async Task CategoryUpdateValidation_CategoryUpdateRequest_ReturnError(CategoryUpdateRequest categoryUpdateRequest)
    {
        CategoryUpdateValidator validation = new(_baseServices.GetValidation());
        TestValidationResult<CategoryUpdateRequest> result = await validation.TestValidateAsync(categoryUpdateRequest);
        result.ShouldHaveAnyValidationError();
    }
    [Theory,MemberData(nameof(SubCategoryCreateRequests))]
    public async Task SubCategoryCreateValidation_SubCategoryCreateRequest_ReturnError(SubCategoryCreateRequest subCategoryCreateRequest)
    {
        SubCategoryCreateValidator validation = new(_baseServices.GetValidation());
        TestValidationResult<SubCategoryCreateRequest> result = await validation.TestValidateAsync(subCategoryCreateRequest);
        result.ShouldHaveAnyValidationError();
    }
}
