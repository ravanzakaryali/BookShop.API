using BookShop.Infrastructure.Contracts.Repository.Base;
using BookShop.Persistence.Data;

namespace BookShop.Infrastructure.Contracts.Repository;

public class FormatRepository : Repository<Format, string>, IFormatRepository
{
    public FormatRepository(AppDbContext context) : base(context)
    {
    }
}
