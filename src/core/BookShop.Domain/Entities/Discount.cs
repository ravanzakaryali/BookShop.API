namespace BookShop.Domain.Entities;

public class Discount : BaseAuditableEntity
{
    public decimal DiscounAmaount { get; set; }
    public string BookId { get; set; } = null!;
    public Book Book { get; set; } = null!;
    public Format? Format { get; set; }
    public string? FormatId { get; set; }
    public string LanguageId { get; set; } = null!;
    public Language Language { get; set; } = null!;
    public DateTime StartedDate { get; set; }
    public DateTime EndedDate { get; set; }

}
