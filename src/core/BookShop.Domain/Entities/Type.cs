namespace BookShop.Domain.Entities;

public class Type : BaseEntity,INormalizationName
{
    public Type()
    {
        Books = new HashSet<Book>();
    }
    public string Name { get; set; } = null!;
    public ICollection<Book> Books { get; set; }
    public string NormalizationName { get; set; } = null!;
}
