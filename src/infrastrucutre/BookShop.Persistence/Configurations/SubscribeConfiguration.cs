using BookShop.Domain.Entities;
using BookShop.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Persistence.Configurations;

internal class SubscribeConfiguration : IEntityTypeConfiguration<Subscribe>
{
    public void Configure(EntityTypeBuilder<Subscribe> builder)
    {
        builder.ConfigureBaseEntity();
        builder.Property(s => s.Email).IsRequired();
        builder.HasIndex(s => s.Email).IsUnique();
    }
}
