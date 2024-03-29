﻿using BookShop.Application.Asbtarcts.Common;
using BookShop.Domain.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using BookShop.Domain.Entities;
using BookShop.Application.Extensions;

namespace BookShop.Persistence.Interceptor;

public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly IDateTime _dateTime;
    private readonly IHttpContextAccessor _httpContext;

    public AuditableEntitySaveChangesInterceptor(IDateTime dateTime, IHttpContextAccessor httpContext) 
    {
        _dateTime = dateTime;
        _httpContext = httpContext;
    }
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    public void UpdateEntities(DbContext? context)
    {
        string? name = _httpContext.HttpContext?.User.Identity?.Name;
        if (context is null) return;
        foreach (EntityEntry<BaseAuditableEntity> entity in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.CreatedDate = _dateTime.Now;
                entity.Entity.CreatedBy = name;
            }
            else if (entity.State == EntityState.Modified)
            {
                entity.Entity.LastModifiedDate = _dateTime.Now;
                entity.Entity.LastModifedBy = name;
            }
            else if (entity.State == EntityState.Deleted)
            {
                entity.State = EntityState.Modified;
                entity.Entity.IsDeleted = true;
            }
        }
        foreach (EntityEntry<INormalizationName> entity in context.ChangeTracker.Entries<INormalizationName>())
        {
            entity.Entity.NormalizationName = entity.Entity.Name.CharacterRegulatory(int.MaxValue);
        }
    }
}