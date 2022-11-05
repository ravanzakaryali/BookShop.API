using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Asbtarcts.Repository.Base;

namespace BookShop.Application.Asbtarcts.Repository;

public interface ITypeRepository : IRepository<IApplicationDbContext,E.Type,string>
{
    Task<bool> IsExistAsync(string name);
}
