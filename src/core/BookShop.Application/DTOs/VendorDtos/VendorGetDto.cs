using BookShop.Application.Asbtarcts.Common;
using BookShop.Domain.Entities;

namespace BookShop.Application.DTOs.VendorDtos;

public class VendorGetDto : IMapFrom<Vendor>
{
    public string Fullname { get; set; } = null!;
    public string NormalizationName { get; set; } = null!;
}
