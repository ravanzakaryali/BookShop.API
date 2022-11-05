using BookShop.Application.Asbtarcts.Common;
using BookShop.Domain.Entities;
using BookShop.Infrastructure.Contracts.Repository.Base;
using BookShop.Persistence.Data;

namespace BookShop.Infrastructure.Contracts.Repository;

public class BlogRepository : Repository<Blog, string>, IBlogRepository
{
    public BlogRepository(AppDbContext context) : base(context)
    {
    }
}
