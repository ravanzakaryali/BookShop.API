using BookShop.Application.Asbtarcts.Common;
using BookShop.Domain.Base;
using BookShop.Domain.Entities;
using BookShop.Domain.Identity;
using BookShop.Persistence.Interceptor;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Reflection;
using E = BookShop.Domain.Entities;

namespace BookShop.Persistence.Data;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>, IApplicationDbContext
{
    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
    public AppDbContext(DbContextOptions<AppDbContext> options, AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options)
    {
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<AuthorAward> AuthorAwards => Set<AuthorAward>();
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<BlogerUser> BlogerUsers => Set<BlogerUser>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<BookImage> BookImages => Set<BookImage>();
    public DbSet<BookPrice> BookPrices => Set<BookPrice>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Domain.Entities.File> Files => Set<Domain.Entities.File>();
    public DbSet<Format> Formats => Set<Format>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<Vendor> Vendors => Set<Vendor>();
    public DbSet<BasketItem> Carts => Set<BasketItem>();
    public DbSet<AuthorImage> AuthorImages => Set<AuthorImage>();
    public DbSet<Basket> Baskets => Set<Basket>();
    public DbSet<BasketItem> BasketItems => Set<BasketItem>();
    public DbSet<BlogImage> BlogImages => Set<BlogImage>();
    public DbSet<CustomerUser> CustomerUsers => Set<CustomerUser>();
    public DbSet<Domain.Entities.Type> Types => Set<Domain.Entities.Type>();
    public DbSet<Wishlist> Wishlists => Set<Wishlist>();
    public DbSet<Wishlist> WishlistItems => Set<Wishlist>();
    public DbSet<Discount> Discounts => Set<Discount>();
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        Expression<Func<BaseAuditableEntity, bool>> filterExpr = bm => !bm.IsDeleted;
        foreach (IMutableEntityType mutableEntityType in builder.Model.GetEntityTypes())
        {
            if (mutableEntityType.ClrType.IsAssignableTo(typeof(BaseAuditableEntity)) && 
               !mutableEntityType.ClrType.IsAssignableTo(typeof(E.File)))
            {
                ParameterExpression parameter = Expression.Parameter(mutableEntityType.ClrType);
                Expression? body = ReplacingExpressionVisitor.Replace(filterExpr.Parameters.First(), parameter, filterExpr.Body);
                LambdaExpression lambdaExpression = Expression.Lambda(body, parameter);
                mutableEntityType.SetQueryFilter(lambdaExpression);
            }
            if (typeof(INormalizationName).IsAssignableFrom(mutableEntityType.ClrType))
            {
                builder.Entity(mutableEntityType.ClrType).HasIndex("NormalizationName").IsUnique();
            }
        }

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        base.OnConfiguring(optionsBuilder);
    }
}
