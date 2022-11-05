using BookShop.Application.Common;

namespace BookShop.Application.DTOs;

public class ImageGetDto
{
    public string Id { get; set; } = null!;
    public bool IsMain { get; set; }
    public string ImageUrl { get; set; } = null!;
}
