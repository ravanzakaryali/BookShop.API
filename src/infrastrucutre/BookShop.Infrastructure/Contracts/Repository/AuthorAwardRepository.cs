using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository;
using BookShop.Domain.Entities;
using BookShop.Infrastructure.Contracts.Repository.Base;
using BookShop.Persistence.Data;

namespace BookShop.Infrastructure.Contracts.Repository;

public class AuthorAwardRepository : Repository<AuthorAward, string>, IAuthorAwardRepository
{
    public AuthorAwardRepository(AppDbContext context) : base(context)
    {
    }
}
