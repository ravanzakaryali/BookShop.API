using BookShop.Application.Asbtarcts.Common;
using BookShop.Persistence.Data;
using BookShop.Persistence.Interceptor;
using BookShop.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Persistence;

public static class ConfigureService
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Database"),
                   builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppDbContext>());
        services.AddScoped<AppDbContextIntialiser>();
        return services;
    }
}
