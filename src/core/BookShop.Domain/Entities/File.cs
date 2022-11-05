namespace BookShop.Domain.Entities;

public class File : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Storage { get; set; } = null!;
    public string StorageUrl { get; set; } = null!;
    public string? Path { get; set; }
}
