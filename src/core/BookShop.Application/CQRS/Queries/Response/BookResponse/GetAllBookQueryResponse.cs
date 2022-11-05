using BookShop.Application.Common;
using BookShop.Application.DTOs;

namespace BookShop.Application.CQRS.Queries.Response.BookResponse;

internal class GetAllBookQueryResponse : IMapFrom<Book>
{
    public string ImageUrl { get; set; } = null!;
    public VendorGetDto Vendor { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string NormalizationName { get; set; } = null!;
    public decimal Price { get; set; }
}
