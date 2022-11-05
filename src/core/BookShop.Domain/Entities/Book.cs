namespace BookShop.Domain.Entities;

public class Book : BaseAuditableEntity, INormalizationName
{
    public Book()
    {
        Formats = new HashSet<Format>();
        Languages = new HashSet<Language>();
        Reviews = new HashSet<Review>();
        Authors = new HashSet<Author>();
        BookImages = new HashSet<BookImage>();
        BasketItems = new HashSet<BasketItem>();
        WishlistItems = new HashSet<Wishlist>();
        BookPrices = new HashSet<BookPrice>();
        Sales = new HashSet<Sale>();
    }
    public string Name { get; set; } = null!;
    public string NormalizationName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double AverageRating { get; set; }

    public string VendorId { get; set; } = null!;
    public Vendor Vendor { get; set; } = null!;
    public string CategoryId { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public string? TypeId { get; set; }
    public Type? Type { get;set; } 
    public string? DiscountId { get; set; }
    public Discount? Discount { get; set; } 
    public ICollection<Sale> Sales { get; set; }
    public ICollection<BookPrice> BookPrices { get; set; }
    public ICollection<Format> Formats { get; set; }
    public ICollection<Author> Authors { get; set; }
    public ICollection<Language> Languages { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<BookImage> BookImages { get; set; }
    public ICollection<BasketItem> BasketItems { get; set; }
    public ICollection<Wishlist> WishlistItems { get; set; }
}
