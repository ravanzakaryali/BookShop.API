using BookShop.Application.Common;

namespace BookShop.Application.DTOs;

public class FormatGetDto : IMapFrom<Format>
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
}
