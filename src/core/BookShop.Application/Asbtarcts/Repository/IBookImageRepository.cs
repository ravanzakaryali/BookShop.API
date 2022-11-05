using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository.Base;

namespace BookShop.Application.Asbtarcts.Repository;

public interface IBookImageRepository : IRepository<IApplicationDbContext,BookImage,string>
{
}
