using System.Dynamic;

namespace BookShop.Application.Asbtarcts.Common;

public interface IApplicationDbContext
{
    DbSet<Author> Authors { get; }
    DbSet<AuthorAward> AuthorAwards { get; }
    DbSet<AuthorImage> AuthorImages { get; }
    DbSet<Basket> Baskets { get; }
    DbSet<BasketItem> BasketItems { get; }
    DbSet<Blog> Blogs { get; }
    DbSet<BlogerUser> BlogerUsers { get; }
    DbSet<BlogImage> BlogImages { get; }
    DbSet<Book> Books { get; }
    DbSet<BookImage> BookImages { get; }
    DbSet<BookPrice> BookPrices { get; }
    DbSet<Category> Categories { get; }
    DbSet<Comment> Comments { get; }
    DbSet<CustomerUser> CustomerUsers { get; }
    DbSet<E.File> Files { get; }
    DbSet<Format> Formats { get; }
    DbSet<Language> Languages { get; }
    DbSet<Review> Reviews { get; }
    DbSet<Sale> Sales { get; }
    DbSet<E.Type> Types { get; }
    DbSet<Vendor> Vendors { get; }
    DbSet<Wishlist> Wishlists { get; }
    DbSet<Wishlist> WishlistItems { get; }
    DbSet<Discount> Discounts { get; }
    DbSet<TEntity> Set<TEntity>() where TEntity : class; 
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
