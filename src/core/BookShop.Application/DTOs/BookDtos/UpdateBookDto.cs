using BookShop.Application.Common;

namespace BookShop.Application.DTOs;

public class UpdateBookDto : IMapFrom<Book>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string VendorId { get; set; } = null!;
    public decimal Price { get; set; }
    public string CategoryId { get; set; } = null!;
    public string? TypeId { get; set; }
}
