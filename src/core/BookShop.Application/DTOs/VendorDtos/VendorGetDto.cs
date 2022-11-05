using BookShop.Application.Common;

namespace BookShop.Application.DTOs;

public class VendorGetDto : IMapFrom<Vendor>
{
    public string Id { get; set; } = null!;
    public string Fullname { get; set; } = null!;
    public string NormalizationName { get; set; } = null!;
}
