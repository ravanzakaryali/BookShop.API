using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository;
using BookShop.Application.Asbtarcts.Repository.Base;
using BookShop.Application.Contracts.Repository.Base;
using BookShop.Domain.Entities;

namespace BookShop.Application.Contracts.Repository;

public class AuthorRepository : Repository<IApplicationDbContext, Author, string>, IAuthorRepository
{
    public AuthorRepository(IApplicationDbContext context) : base(context)
    {
    }
}
