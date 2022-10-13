using BookShop.Application.Asbtarcts.Common;
using BookShop.Domain.Entities;

namespace BookShop.Application.DTOs.PriceDtos;

public class BookPriceDto : IMapFrom<BookPrice>
{
    public decimal Price { get; set; }
    public string BookId { get; set; } = null!;
    public string? FormatId { get; set; }
    public string LanguageId { get; set; } = null!;
}
