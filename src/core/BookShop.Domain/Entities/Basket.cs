namespace BookShop.Domain.Entities;

public class Basket : BaseEntity
{
    public Basket()
    {
        BasketItems = new HashSet<BasketItem>();
    }
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; } = null!;
    public ICollection<BasketItem> BasketItems { get; set; }
}
