namespace BookShop.Domain.Entities;

public class Author : BaseAuditableEntity,INormalizationName
{
    public Author()
    {
        Awards = new HashSet<AuthorAward>();
        Books = new HashSet<Book>();
    }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string AuthorImageId { get; set; } = null!;
    public string NormalizationName { get; set; } = null!;
    public AuthorImage AuthorImage { get; set; } = null!;
    public ICollection<AuthorAward> Awards { get; set; }
    public ICollection<Book> Books { get; set; }
}
