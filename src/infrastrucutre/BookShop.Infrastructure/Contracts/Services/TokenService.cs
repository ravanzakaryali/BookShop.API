using BookShop.Application.Asbtarcts.Services;
using BookShop.Domain.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookShop.Infrastructure.Contracts.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateToken(AppUser user, IList<string> roles)
    {
        List<Claim> claims = new()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email),
        };

        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:SecurityKey").Value));
        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken securityToken = new(
            issuer: _configuration.GetSection("Jwt:Issuer").Value,
            audience: _configuration.GetSection("Jwt:Audience").Value,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(45),
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
