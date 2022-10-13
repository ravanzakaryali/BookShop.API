namespace BookShop.Domain.Entities;

public class Vendor : AppUser
{
    public Vendor()
    {
        Books = new HashSet<Book>();
    }
    public ICollection<Book> Books { get; set; }
}
