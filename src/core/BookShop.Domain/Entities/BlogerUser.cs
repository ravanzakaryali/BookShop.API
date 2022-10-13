namespace BookShop.Domain.Entities;

public class BlogerUser : AppUser
{
	public BlogerUser()
	{
		Blogs = new HashSet<Blog>();
	}
    public ICollection<Blog> Blogs { get; set; }
}
