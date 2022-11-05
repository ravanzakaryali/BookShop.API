using BookShop.Infrastructure.Contracts.Repository.Base;
using BookShop.Persistence.Data;

namespace BookShop.Infrastructure.Contracts.Repository;

public class CategoryRepository : Repository<Category, string>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
