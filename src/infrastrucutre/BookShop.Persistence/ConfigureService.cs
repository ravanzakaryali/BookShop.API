using BookShop.Application.Asbtarcts.Common;
using BookShop.Domain.Identity;
using BookShop.Persistence.Data;
using BookShop.Persistence.Interceptor;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookShop.Persistence;

public static class ConfigureService
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("Database"),
                   builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

        services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.Password.RequiredLength = 3;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            //options.User.RequireUniqueEmail = true;
            //options.SignIn.RequireConfirmedEmail = true;
        }).AddEntityFrameworkStores<AppDbContext>();


        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(option =>
        {
            option.TokenValidationParameters = new TokenValidationParameters
            {
                ValidAudience = configuration.GetSection("Jwt:Audience").Value,
                ValidIssuer = configuration.GetSection("Jwt:Issuer").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:SecurityKey").Value)),
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = true,
            };
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<AppDbContext>());
        services.AddScoped<AppDbContextInitialiser>();
        return services;
    }
}
