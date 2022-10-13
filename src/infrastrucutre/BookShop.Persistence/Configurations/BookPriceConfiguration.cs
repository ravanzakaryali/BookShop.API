using BookShop.Domain.Entities;
using BookShop.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Persistence.Configurations;

public class BookPriceConfiguration : IEntityTypeConfiguration<BookPrice>
{
    public void Configure(EntityTypeBuilder<BookPrice> builder)
    {
        builder.ConfigureBaseEntity();
    }
}
