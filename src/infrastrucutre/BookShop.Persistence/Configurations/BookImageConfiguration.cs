using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Persistence.Configurations;

public class BookImageConfiguration : IEntityTypeConfiguration<BookImage>
{
    public void Configure(EntityTypeBuilder<BookImage> builder)
    {
        //builder.ConfigureAuditableBaseEntity();
    }
}
