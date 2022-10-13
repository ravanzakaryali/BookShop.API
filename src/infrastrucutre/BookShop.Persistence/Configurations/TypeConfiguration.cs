using BookShop.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Persistence.Configurations;

public class TypeConfiguration : IEntityTypeConfiguration<Domain.Entities.Type>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Type> builder)
    {
        builder.ConfigureBaseEntity();
    }
}
