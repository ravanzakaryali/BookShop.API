using BookShop.Application.Asbtarcts.UnitOfWork;
using BookShop.Domain.Entities;
using BookShop.Domain.Identity;
using BookShop.Persistence.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Persistence.SeedData;

public class AppDbContextIntialiser
{
    private readonly AppDbContext _dbContext;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public AppDbContextIntialiser(AppDbContext dbContext, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
    {
        _dbContext = dbContext;
        _roleManager = roleManager;
        _userManager = userManager;
    }
    //Todo: Init data
    public async Task InitializeAsync()
    {
        try
        {
            if (_dbContext.Database.IsSqlServer())
            {
                await _dbContext.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);//Todo: Logger
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); //Todo: Logger
        }
    }

    public async Task TrySeedAsync()
    {

        //Identity create
        AppRole administratorRole = new("administrator");
        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }
        
        AppUser admin = new(){ UserName = "revanzli", Email = "revanzli@gmail.com" };
        if (_userManager.Users.All(u => u.UserName != admin.UserName))
        {
            await _userManager.CreateAsync(admin, "Revan2002");
            await _userManager.AddToRoleAsync(admin, administratorRole.Name );
            await _userManager.AddToRolesAsync(admin, new[] { administratorRole.Name });
        }

        if (_dbContext.Categories.Any())
        {
            await _dbContext.Categories.AddRangeAsync(new List<Category>
            {
                new Category
                {
                },
                new Category
                {

                }
            });
        }
    }
}
