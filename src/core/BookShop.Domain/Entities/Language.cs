namespace BookShop.Domain.Entities;

public class Language : BaseEntity
{
    public Language()
    {
        Books = new HashSet<Book>();
    }
    public string Name { get; set; } = null!;
    public string NormalizationName { get; set; } = null!;
    public ICollection<Book> Books { get; set; }
}
