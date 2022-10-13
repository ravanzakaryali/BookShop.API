using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository.Base;

namespace BookShop.Application.Asbtarcts.Repository;

public interface IBlogRepository : IRepository<IApplicationDbContext,Blog, string>
{
}
