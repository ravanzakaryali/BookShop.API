using BookShop.Domain.Entities;
using BookShop.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ConfigureAuditableBaseEntity();
        builder.HasOne(b => b.BookPrice)
               .WithOne(p => p.Book)
               .HasForeignKey<BookPrice>(p => p.BookId);
        builder
        .HasMany(b => b.Reviews)
        .WithOne(c => c.Book)
        .HasForeignKey(c => c.BookId)
        .OnDelete(DeleteBehavior.Restrict);

        builder
         .HasMany(b => b.WishlistItems)
         .WithOne(c => c.Book)
         .HasForeignKey(c => c.BookId)
         .OnDelete(DeleteBehavior.Restrict);

        builder
          .HasMany(b => b.BasketItems)
          .WithOne(c => c.Book)
          .HasForeignKey(c => c.BookId)
          .OnDelete(DeleteBehavior.Restrict);


    }
}
