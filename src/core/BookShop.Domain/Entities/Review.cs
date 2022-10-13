namespace BookShop.Domain.Entities;

public class Review : BaseAuditableEntity
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public double? Raiting { get; set; }
    public AppUser User { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public Book Book { get; set; } = null!;
    public string BookId { get; set; } = null!;
}
