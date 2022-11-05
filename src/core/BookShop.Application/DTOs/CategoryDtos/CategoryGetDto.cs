using BookShop.Application.Common;

namespace BookShop.Application.DTOs;

public class CategoryGetDto : IMapFrom<Category>
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}
