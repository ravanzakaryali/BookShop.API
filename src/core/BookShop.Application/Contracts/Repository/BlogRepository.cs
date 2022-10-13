using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Contracts.Repository.Base;

namespace BookShop.Application.Contracts.Repository;

public class BlogRepository : Repository<IApplicationDbContext, Blog, string>, IBlogRepository
{
    public BlogRepository(IApplicationDbContext context) : base(context)
    {
    }
}
