namespace BookShop.Application.DTOs.ReviewDtos;

public class ReviewCommandDto
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public double? Raiting { get; set; }
}
