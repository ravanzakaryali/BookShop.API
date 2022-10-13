using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.DTOs.CategoryDtos;
using BookShop.Application.DTOs.FormatDtos;
using BookShop.Application.DTOs.FileDto;
using BookShop.Application.DTOs.LanguageDtos;
using BookShop.Application.DTOs.PriceDtos;
using BookShop.Application.DTOs.TypeDtos;
using BookShop.Application.DTOs.VendorDtos;
using BookShop.Domain.Entities;

namespace BookShop.Application.CQRS.Queries.Response.BookResponse;

public class GetBookQueryResponse : IMapFrom<Book>
{
    public string Title { get; set; } = null!;
    public string NormalizationName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double AverageRating { get; set; }
    public BookPriceDto BookPrice { get; set; } = null!;
    public VendorGetDto Vendor { get; set; } = null!;
    public CategoryGetDto Category { get; set; } = null!;
    public TypeGetDto? Types { get; set; }
    public ICollection<FormatGetDto>? Formats { get; set; }
    public ICollection<LanguageGetDto> Languages { get; set; } = null!;
    public ICollection<ImageGetDto> BookImages { get; set; } = null!;

}
