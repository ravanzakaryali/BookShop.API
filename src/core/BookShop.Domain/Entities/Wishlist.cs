namespace BookShop.Domain.Entities;

public class Wishlist : BaseEntity
{
    public string BookId { get; set; } = null!;
    public Book Book { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; } = null!;
}
