using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository;
using BookShop.Domain.Entities;
using BookShop.Infrastructure.Contracts.Repository.Base;
using BookShop.Persistence.Data;

namespace BookShop.Infrastructure.Contracts.Repository;

public class AuthorImageRepository : Repository<AuthorImage, string>, IAuthorImageRepository
{
    public AuthorImageRepository(AppDbContext context) : base(context)
    {
    }
}
