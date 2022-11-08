using BookShop.Application.CQRS.Commands.Request.CategoryRequest;
using BookShop.Application.DTOs.CategoryDtos;

namespace BookShop.Application.Test.TestData.EntitiesData;

public class CategoryData
{
    public static IEnumerable<CategoryCreateRequest[]> CategoryCreateRequests
    {
        get
        {
            yield return new CategoryCreateRequest[] 
            {
                new CategoryCreateRequest("")
            };
            yield return new CategoryCreateRequest[]
            {
                new CategoryCreateRequest(" ")
            };
            yield return new CategoryCreateRequest[]
            {
                new CategoryCreateRequest(new string('A',33))
            };

        }
    }
    public static IEnumerable<CategoryUpdateRequest[]> CategoryUpdateRequests
    {
        get
        {
            yield return new CategoryUpdateRequest[]
            {
                new CategoryUpdateRequest(Guid.NewGuid().ToString(),new CategoryCommandDto()
                {
                    Name = "",
                })
            };
            yield return new CategoryUpdateRequest[]
            {
                new CategoryUpdateRequest(Guid.NewGuid().ToString(),new CategoryCommandDto()
                {
                    Name = " "
                })
            };
            yield return new CategoryUpdateRequest[]
            {
                new CategoryUpdateRequest(Guid.NewGuid().ToString(),new CategoryCommandDto()
                {
                    Name = new string('A',33)
                })
            };
        }
    }
    public static IEnumerable<SubCategoryCreateRequest[]> SubCategoryCreateRequests
    {
        get
        {
            yield return new SubCategoryCreateRequest[]
            {
                new SubCategoryCreateRequest(Guid.NewGuid().ToString(),new CategoryCommandDto()
                {
                    Name = ""
                })
            };
            yield return new SubCategoryCreateRequest[]
            {
                new SubCategoryCreateRequest(Guid.NewGuid().ToString(),new CategoryCommandDto()
                {
                    Name = " "
                })
            };
            yield return new SubCategoryCreateRequest[]
            {
                new SubCategoryCreateRequest(Guid.NewGuid().ToString(),new CategoryCommandDto()
                {
                    Name = new string('A',33)
                })
            };
        }
    }
}
