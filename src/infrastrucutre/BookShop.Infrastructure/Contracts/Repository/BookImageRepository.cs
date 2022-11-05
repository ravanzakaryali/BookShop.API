using BookShop.Infrastructure.Contracts.Repository.Base;
using BookShop.Persistence.Data;

namespace BookShop.Infrastructure.Contracts.Repository;

public class BookImageRepository : Repository<BookImage, string>, IBookImageRepository
{
    public BookImageRepository(AppDbContext context) : base(context)
    {
    }
}
