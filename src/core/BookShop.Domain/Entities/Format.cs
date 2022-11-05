namespace BookShop.Domain.Entities;

public class Format : BaseEntity, INormalizationName
{
    public Format()
    {
        Books = new HashSet<Book>();
    }
    public string Name { get; set; } = null!;
    public ICollection<Book> Books { get; set; }
    public string NormalizationName { get; set; } = null!;
}
