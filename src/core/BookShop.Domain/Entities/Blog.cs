namespace BookShop.Domain.Entities;

public class Blog : BaseAuditableEntity, INormalizationName
{
    public Blog()
    {
        Comments = new HashSet<Comment>();
        BlogImages = new HashSet<BlogImage>();
    }
    public string Name { get; set; } = null!;
    public BlogerUser User { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string NormalizationName { get; set; } = null!;
    public ICollection<Comment> Comments { get; set; }
    public ICollection<BlogImage> BlogImages { get; set; } = null!;
}
