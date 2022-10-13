using BookShop.Domain.Entities;
using BookShop.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Persistence.Configurations;

public class AuthorAwardConfiguration : IEntityTypeConfiguration<AuthorAward>
{
    public void Configure(EntityTypeBuilder<AuthorAward> builder)
    {
        builder.ConfigureBaseEntity();
    }
}
