namespace BookShop.Domain.Entities;

public class Format : BaseEntity
{
    public Format()
    {
        Books = new HashSet<Book>();
    }
    public string Name { get; set; } = null!;
    public ICollection<Book> Books { get; set; }
}
