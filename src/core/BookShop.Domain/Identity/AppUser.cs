using BookShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookShop.Domain.Identity;

public class AppUser : IdentityUser
{
    public string Fullname { get; set; } = null!;
}
