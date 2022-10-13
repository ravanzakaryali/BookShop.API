using BookShop.Application.Asbtarcts.Common;
namespace BookShop.Application.DTOs.TypeDtos;

public class TypeGetDto : IMapFrom<E.Type>
{
    public string Name { get; set; } = null!;
}
