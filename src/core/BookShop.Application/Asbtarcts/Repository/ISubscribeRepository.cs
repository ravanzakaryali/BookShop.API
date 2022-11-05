using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository.Base;

namespace BookShop.Application.Asbtarcts.Repository;

public interface ISubscribeRepository : IRepository<IApplicationDbContext, Subscribe, string>
{
}
