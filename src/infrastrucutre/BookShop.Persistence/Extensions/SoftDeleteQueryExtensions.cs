using BookShop.Domain.Base;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Reflection;

namespace BookShop.Persistence.Extensions;

public static class SoftDeleteQueryExtension
{
    public static void AddSoftDeleteQueryFilter(
        this IMutableEntityType entityData)
    {
        MethodInfo? methodToCall = typeof(SoftDeleteQueryExtension)
            .GetMethod(nameof(GetSoftDeleteFilter),
                BindingFlags.NonPublic | BindingFlags.Static)?
            .MakeGenericMethod(entityData.ClrType);
        object? filter = methodToCall?.Invoke(null, Array.Empty<object>());
        entityData.SetQueryFilter((LambdaExpression)filter!);
        entityData.AddIndex(entityData.
             FindProperty(nameof(BaseEntity.IsDeleted))!);
    }

    private static LambdaExpression GetSoftDeleteFilter<TEntity>()
        where TEntity : BaseEntity
    {
        Expression<Func<TEntity, bool>> filter = e => e.IsDeleted;
        return filter;
    }
}
