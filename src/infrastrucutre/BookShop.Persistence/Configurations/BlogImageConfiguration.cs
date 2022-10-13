using BookShop.Domain.Entities;
using BookShop.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Persistence.Configurations;

public class BlogImageConfiguration : IEntityTypeConfiguration<BlogImage>
{
    public void Configure(EntityTypeBuilder<BlogImage> builder)
    {
        //builder.ConfigureAuditableBaseEntity();
    }
}
