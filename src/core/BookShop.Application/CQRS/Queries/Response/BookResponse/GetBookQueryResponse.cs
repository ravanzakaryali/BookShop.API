using BookShop.Application.Common;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Queries.Response.BookResponse;

internal class GetBookQueryResponse : IMapFrom<Book>
{
    public string Title { get; set; } = null!;
    public string NormalizationName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double AverageRating { get; set; }
    public ICollection<BookPriceDto> BookPrices { get; set; } = null!;
    public VendorGetDto Vendor { get; set; } = null!;
    public CategoryGetDto Category { get; set; } = null!;
    public TypeGetDto? Types { get; set; }
    public ICollection<FormatGetDto>? Formats { get; set; }
    public ICollection<LanguageGetDto> Languages { get; set; } = null!;
    public ICollection<ImageGetDto> BookImages { get; set; } = null!;

}
