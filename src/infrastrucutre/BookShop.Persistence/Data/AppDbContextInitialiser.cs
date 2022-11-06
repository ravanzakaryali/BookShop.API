using BookShop.Application.Common;
using BookShop.Domain.Entities;
using BookShop.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EntityType = BookShop.Domain.Entities.Type;
namespace BookShop.Persistence.Data;

public class AppDbContextInitialiser
{
    private readonly AppDbContext _dbContext;
    private readonly RoleManager<AppRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public AppDbContextInitialiser(AppDbContext dbContext, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
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
            throw;
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
            throw;
        }
    }

    public async Task TrySeedAsync()
    {

        //Identity create
        AppRole administratorRole = new()
        {
            Name = "Admin"
        };
        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        AppUser admin = new() { Fullname = "Revan Zakaryali", UserName = "revanzli", Email = "revanzli@gmail.com" };
        if (_userManager.Users.All(u => u.UserName != admin.UserName))
        {
            await _userManager.CreateAsync(admin, "Revan2002");
            await _userManager.AddToRoleAsync(admin, administratorRole.Name);
            await _userManager.AddToRolesAsync(admin, new[] { administratorRole.Name });
        }

        if (!_dbContext.Types.Any())
        {

            await _dbContext.Types.AddRangeAsync(new List<EntityType>
            {
                new EntityType
                {
                    Id = "2bddfe4d-dd84-48d6-9728-28e236723810",
                    Name = "Business",
                },
                new EntityType
                {
                    Id = "2bddfe4d-dd84-48d6-9728-28e236723811",
                    Name = "Entertainment"
                }
            });
        }
        if (!_dbContext.Formats.Any())
        {
            await _dbContext.Formats.AddRangeAsync(new List<Format>
            {
                new Format
                {
                    Id = "2bddfe4d-dd84-48d6-9728-28e236723802",
                    Name = "Kindle Edition",
                }
            });
        }
        if (!_dbContext.Languages.Any())
        {
            await _dbContext.Languages.AddRangeAsync(new List<Language>
            {
                new Language
                {
                    Id = "2bddfe4d-dd84-48d6-9728-28e236723803",
                    Name = "English",
                    NormalizationName = "english"
                },
                new Language
                {
                    Id="2bddfe4d-dd84-48d6-9728-28e236723804",
                    Name = "Spanish",
                    NormalizationName = "spanish"
                }
            });
        }
        if (!_dbContext.Vendors.Any())
        {
            await _dbContext.Vendors.AddRangeAsync(new List<Vendor>
            {
                new Vendor
                {
                    Id ="2bddfe4d-dd84-48d6-9728-28e236723806",
                    UserName = "donaldwilliam",
                    Fullname = "Doanld Willim",
                    Email = "donaldWilliam@code.edu.az",
                },
                new Vendor
                {
                    Id ="2bddfe4d-dd84-48d6-9728-28e236723807",
                    UserName = "MichaelAlice",
                    Fullname = "Michael Alice",
                    Email = "Michael Alice@code.edu.az"
                },
            });
        }
        if (!_dbContext.Categories.Any())
        {
            await _dbContext.Categories.AddRangeAsync(new List<Category>
            {
                new Category
                {
                    Id = "4ea29640-7534-455a-8fe5-a88dca019ca0",
                    Name = "History",
                },
                new Category
                {
                    Id = "4ea29640-7534-455a-8fe5-a88dca019ca1",
                    Name = "Fiction"
                },
                new Category
                {
                    Id = "4ea29640-7534-455a-8fe5-a88dca019ca2",
                    Name = "Business"
                },
                new Category
                {
                    Id = "4ea29640-7534-455a-8fe5-a88dca019ca3",
                    Name = "Architechture"
                },
                new Category
                {
                    Id = "4ea29640-7534-455a-8fe5-a88dca019ca4",
                    Name = "Poetry"
                }
            });
        }

        if (!_dbContext.Books.Any() && 
            !_dbContext.Languages.Any() && 
            !_dbContext.Formats.Any() && 
            !_dbContext.BookPrices.Any())
        {
            await _dbContext.Books.AddRangeAsync(new List<Book>
            {
                new Book
                {
                    Name = "Books For a Cause",
                    Id = "4ea29640-7534-455a-8fe5-a88dca019cb1",
                    VendorId = "2bddfe4d-dd84-48d6-9728-28e236723807",
                    Formats = new List<Format>
                    {
                        new Format
                        {
                            Id = "2bddfe4d-dd84-48d6-9728-28e236723800",
                            Name = "Paperback",
                        },
                        new Format
                        {
                            Id = "2bddfe4d-dd84-48d6-9728-28e236723801",
                            Name = "Hardcover"
                        }
                    },
                    Languages = new List<Language>
                    {
                          new Language
                          {
                             Id="2bddfe4d-dd84-48d6-9728-28e236723805",
                             Name = "Japanse",
                             NormalizationName = "japanse"
                          }
                    },
                    BookPrices = new List<BookPrice>
                    {
                        new BookPrice
                        {
                            Id = "2bddfe4d-dd84-48d6-9728-28e236723111",
                            FormatId = "2bddfe4d-dd84-48d6-9728-28e236723801",
                            LanguageId = "2bddfe4d-dd84-48d6-9728-28e236723805",
                            Price = 700,
                        },
                    },
                    CategoryId = "4ea29640-7534-455a-8fe5-a88dca019ca0",
                    DiscountId = "4ea29640-7534-455a-8fe5-a88dca019cb1",
                    Description = "Nam tempus turpis at metus scelerisque placerat nulla deumantos solicitud felis. Pellentesque diam dolor, elementum etos lobortis des mollis ut risus. Sedcus faucibus an sullamcorper mattis drostique des commodo pharetras...",
                    TypeId = "2bddfe4d-dd84-48d6-9728-28e236723810"
                }
            });
        }

        if (!_dbContext.Discounts.Any())
        {
            await _dbContext.Discounts.AddRangeAsync(new List<Discount>
            {
                new Discount
                {
                    DiscounAmaount = 300,
                    BookId = "4ea29640-7534-455a-8fe5-a88dca019cb1",
                    FormatId = "2bddfe4d-dd84-48d6-9728-28e236723800",
                    LanguageId = "2bddfe4d-dd84-48d6-9728-28e236723803",
                },
            });
        }

        await _dbContext.SaveChangesAsync();
        await CreateRoles();

    }
    public async Task CreateRoles()
    {
        foreach (var item in Enum.GetValues(typeof(AppRoles)))
        {
            if (!(await _roleManager.RoleExistsAsync(item.ToString())))
            {
                await _roleManager.CreateAsync(new AppRole
                {
                    Name = item.ToString()
                });
            }
        }
    }
}
