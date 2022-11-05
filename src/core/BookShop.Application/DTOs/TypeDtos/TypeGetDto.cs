using BookShop.Application.Common;

namespace BookShop.Application.DTOs;

public class TypeGetDto : IMapFrom<E.Type>
{
    public string Name { get; set; } = null!;
}
