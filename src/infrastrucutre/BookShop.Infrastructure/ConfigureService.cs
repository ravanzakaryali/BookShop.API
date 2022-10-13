using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Services.Storage;
using BookShop.Infrastructure.Services;
using BookShop.Infrastructure.Services.Storage;
using BookShop.Infrastructure.Services.Storage.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddScoped<IStorage, AzureStorage>();
        services.AddScoped<IStorageService, StorageService>();
        services.AddStorage<AzureStorage>();
        return services;
    }
    public static void AddStorage<TStorage>(this IServiceCollection services) where TStorage : class, IStorage
    {
        services.AddScoped<IStorage, TStorage>();
    }
}
