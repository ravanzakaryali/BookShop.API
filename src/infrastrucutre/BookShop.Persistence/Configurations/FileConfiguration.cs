using BookShop.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Persistence.Configurations;

public class FileConfiguration : IEntityTypeConfiguration<Domain.Entities.File>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.File> builder)
    {
        builder.ConfigureAuditableBaseEntity();
    }
}
