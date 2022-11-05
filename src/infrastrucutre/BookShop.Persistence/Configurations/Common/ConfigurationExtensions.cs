using BookShop.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Emit;

namespace BookShop.Persistence.Configurations.Common;

public static class ConfigurationExtensions
{
    public static EntityTypeBuilder<TEntity> ConfigureBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
          where TEntity : BaseEntity<string>
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasDefaultValueSql("NEWID()");
        builder.Property(e => e.IsDeleted).HasDefaultValue(false);
        return builder;
    }
    public static EntityTypeBuilder<TEntity> ConfigureAuditableBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : BaseAuditableEntity<string>
    {
        builder.ConfigureBaseEntity();
        builder.Property(e => e.CreatedBy).HasMaxLength(200).IsRequired(false);
        builder.Property(e => e.CreatedDate).HasDefaultValueSql("Getutcdate()");
        builder.Property(e => e.LastModifedBy).HasMaxLength(200);
        return builder;
    }
}
