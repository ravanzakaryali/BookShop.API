using BookShop.Infrastructure.Contracts.Repository.Base;
using BookShop.Persistence.Data;

namespace BookShop.Infrastructure.Contracts.Repository;

public class SubscribeRepository : Repository<Subscribe, string>, ISubscribeRepository
{
    public SubscribeRepository(AppDbContext context) : base(context)
    {
    }
}
