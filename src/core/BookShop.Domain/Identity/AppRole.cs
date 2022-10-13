using Microsoft.AspNetCore.Identity;

namespace BookShop.Domain.Identity;

public class AppRole : IdentityRole
{
	public AppRole(string roleName) : base(roleName) { }
}
