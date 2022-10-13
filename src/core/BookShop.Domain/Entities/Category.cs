namespace BookShop.Domain.Entities;

public class Category : BaseEntity, INormalizationName
{
    public Category()
    {
        SubCategories = new HashSet<Category>();
    }
    public string Name { get; set; } = null!;
    public string NormalizationName { get; set; } = null!;
    public Category? SubCategory { get; set; }
    public string? SubCategoryId { get; set; }
    public ICollection<Book> Books { get; set; } = null!;
    public ICollection<Category> SubCategories { get; set; }
}
