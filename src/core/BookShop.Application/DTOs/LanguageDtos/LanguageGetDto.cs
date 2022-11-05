using BookShop.Application.Common;

namespace BookShop.Application.DTOs;

public class LanguageGetDto : IMapFrom<Language>
{
    public string LanguageId { get; set; } = null!;
    public string Name { get; set; } = null!;
}
