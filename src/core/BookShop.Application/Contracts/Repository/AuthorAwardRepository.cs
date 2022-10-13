using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository;
using BookShop.Application.Contracts.Repository.Base;
using BookShop.Domain.Entities;

namespace BookShop.Application.Contracts.Repository;

public class AuthorAwardRepository : Repository<IApplicationDbContext, AuthorAward, string>, IAuthorAwardRepository
{
    public AuthorAwardRepository(IApplicationDbContext context) : base(context)
    {
    }
}
