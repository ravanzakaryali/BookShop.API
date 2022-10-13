namespace BookShop.Domain.Entities;

public class Author : BaseAuditableEntity
{
    public Author()
    {
        Awards = new HashSet<AuthorAward>();
        Books = new HashSet<Book>();
    }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string AuthorImageId { get; set; } = null!;
    public ICollection<AuthorImage> AuthorImage { get; set; }
    public ICollection<AuthorAward> Awards { get; set; }
    public ICollection<Book> Books { get; set; }

}
