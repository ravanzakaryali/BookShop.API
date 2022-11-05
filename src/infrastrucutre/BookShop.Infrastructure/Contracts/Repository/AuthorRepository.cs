using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository;
using BookShop.Application.Asbtarcts.Repository.Base;
using BookShop.Domain.Entities;
using BookShop.Infrastructure.Contracts.Repository.Base;
using BookShop.Persistence.Data;

namespace BookShop.Infrastructure.Contracts.Repository;

public class AuthorRepository : Repository<Author, string>, IAuthorRepository
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }
}
