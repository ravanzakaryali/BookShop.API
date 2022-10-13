using BookShop.Application.Asbtarcts.Common;
using BookShop.Application.Contracts.Repository.Base;

namespace BookShop.Application.Contracts.Repository;

public class ReviewRepository : Repository<IApplicationDbContext, Review, string>, IReviewRepository
{
    public ReviewRepository(IApplicationDbContext context) : base(context)
    {
    }
}
