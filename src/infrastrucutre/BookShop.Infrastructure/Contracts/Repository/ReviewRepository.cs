using BookShop.Application.Asbtarcts.Common;
using BookShop.Infrastructure.Contracts.Repository.Base;
using BookShop.Persistence.Data;

namespace BookShop.Infrastructure.Contracts.Repository;

public class ReviewRepository : Repository<Review, string>, IReviewRepository
{
    public ReviewRepository(AppDbContext context) : base(context)
    {
    }
}
