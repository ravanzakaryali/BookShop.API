using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository;
using BookShop.Application.Contracts.Repository.Base;
using BookShop.Domain.Entities;

namespace BookShop.Application.Contracts.Repository;

public class AuthorImageRepository : Repository<IApplicationDbContext, AuthorImage, string>, IAuthorImageRepository
{
    public AuthorImageRepository(IApplicationDbContext context) : base(context)
    {
    }
}
