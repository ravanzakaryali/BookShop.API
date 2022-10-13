namespace BookShop.Domain.Entities;

public class AuthorImage : File
{
    public Author Author { get; set; } = null!;    
}

