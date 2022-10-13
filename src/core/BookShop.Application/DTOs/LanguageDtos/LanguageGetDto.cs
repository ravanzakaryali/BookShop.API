using BookShop.Application.Asbtarcts.Common;
using BookShop.Domain.Entities;

namespace BookShop.Application.DTOs.LanguageDtos;

public class LanguageGetDto : IMapFrom<Language>
{
    public string LanguageId { get; set; } = null!;
    public string Name { get; set; } = null!;
}
