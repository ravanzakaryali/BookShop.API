namespace BookShop.Domain.Entities;

public class Sale : BaseAuditableEntity
{
    public Sale()
    {
        Books = new HashSet<Book>();
    }
    public string EmailOrNumber { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string? Firstname { get; set; }
    public string Lastname { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Apartment { get; set; }
    public int PostalCode { get; set; }
    public string City { get; set; } = null!;
    public decimal TotalPrice { get; set; }
    public ICollection<Book> Books { get; set; }
}
