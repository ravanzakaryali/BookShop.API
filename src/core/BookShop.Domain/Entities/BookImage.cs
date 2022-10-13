namespace BookShop.Domain.Entities;

public class BookImage : File
{
    public bool IsMain { get; set; }
    public Book Books { get; set; } = null!;
}
