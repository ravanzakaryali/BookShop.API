namespace BookShop.Domain.Entities;

public class BlogImage : File
{
	public bool IsMain { get; set; }
    public Blog Blog { get; set; } = null!;
}
