namespace BookShop.Domain.Entities;

public class CustomerUser : AppUser
{
	public CustomerUser()
	{
		CartItems = new HashSet<BasketItem>();
	}
    public ICollection<BasketItem> CartItems { get; set; }
}
