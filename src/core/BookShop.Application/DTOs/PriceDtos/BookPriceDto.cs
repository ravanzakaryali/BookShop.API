using BookShop.Application.Common;

namespace BookShop.Application.DTOs;

public class BookPriceDto : IMapFrom<BookPrice>
{
    public decimal Price { get; set; }
    public string BookId { get; set; } = null!;
    public string? FormatId { get; set; }
    public string LanguageId { get; set; } = null!;
}
