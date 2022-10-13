using BookShop.Domain.Entities;
using BookShop.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Persistence.Configurations;

public class AuthorImageConfiguration : IEntityTypeConfiguration<AuthorImage>
{
    public void Configure(EntityTypeBuilder<AuthorImage> builder)
    {
        //builder.ConfigureAuditableBaseEntity();
    }
}
