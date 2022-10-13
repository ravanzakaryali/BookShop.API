namespace BookShop.Domain.Entities;

public class BasketItem : BaseEntity
{
    public string BasketId { get; set; } = null!;
    public Basket Basket { get; set; } = null!;
    public string BookId { get; set; } = null!;
    public Book Book { get; set; } = null!;
    public int Count { get; set; }
}
