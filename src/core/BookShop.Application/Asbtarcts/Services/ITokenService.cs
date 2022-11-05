using BookShop.Domain.Identity;

namespace BookShop.Application.Asbtarcts.Services;

public interface ITokenService
{
    string GenerateToken(AppUser user, IList<string> roles);
}
