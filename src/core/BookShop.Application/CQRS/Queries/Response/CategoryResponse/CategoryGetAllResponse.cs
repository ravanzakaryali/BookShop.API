using BookShop.Application.Common;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Queries.Response.CategoryResponse;

public class CategoryGetAllResponse : IMapFrom<Category>
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<CategoryGetDto>? SubCategories { get; set; } 
}
