namespace BookShop.Domain.Entities;

public class Comment : BaseAuditableEntity
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; } = null!;
    public Blog Blog { get; set; } = null!;
    public string BlogId { get; set; } = null!;
}
